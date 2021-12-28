#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("C460E2B4-E199-412a-8456-84DC3E4838C3")]
    [ComVisible(true)]
    public interface IObjectHandle
    {
        // Unwrap the object. Implementers of this interface
        // typically have an indirect referece to another object.
        object Unwrap();
    }


    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class ObjectHandle :
#if FEATURE_REMOTING
        MarshalByRefObject, 
#endif
        IObjectHandle
    {
        private object WrappedObject;

        private ObjectHandle()
        {
        }

        public ObjectHandle(object o)
        {
            WrappedObject = o;
        }

        public Object Unwrap()
        {
            return WrappedObject;
        }

        // ObjectHandle has a finite lifetime. For now the default
        // lifetime is being used, this can be changed in this method to
        // specify a custom lifetime.
#if FEATURE_REMOTING
        [System.Security.SecurityCritical]  // auto-generated_required
        public override Object InitializeLifetimeService()
        {
            BCLDebug.Trace("REMOTE", "ObjectHandle.InitializeLifetimeService");
 
            //
            // If the wrapped object has implemented InitializeLifetimeService to return null,
            // we don't want to go to the base class (which will result in a lease being
            // requested from the MarshalByRefObject, which starts up the LeaseManager,
            // which starts up the ThreadPool, adding three threads to the process.
            // We check if the wrapped object is a MarshalByRef object, and call InitializeLifetimeServices on it
            // and if it returns null, we return null. Otherwise we fall back to the old behavior.
            //
 
            MarshalByRefObject mbr = WrappedObject as MarshalByRefObject;
            if (mbr != null) {
                Object o = mbr.InitializeLifetimeService();
                if (o == null)
                    return null;
            }
            ILease lease = (ILease)base.InitializeLifetimeService();
            return lease;
        }
#endif // FEATURE_REMOTING
    }
}

namespace System
{
    using System.Runtime.Remoting;

    public static class AppDomainExtensions
    {



        [ResourceExposure(ResourceScope.Machine)]
        [ResourceConsumption(ResourceScope.Machine)]
        private static ObjectHandle CreateInstanceFromInternal(String assemblyFile,
                                                               String typeName,
                                                               bool ignoreCase,
                                                               BindingFlags bindingAttr,
                                                               Binder binder,
                                                               object[] args,
                                                               Globalization.CultureInfo culture,
                                                               object[] activationAttributes,
                                                               Security.Policy.Evidence securityInfo)
        {
#if FEATURE_CAS_POLICY
            Contract.Assert(AppDomain.CurrentDomain.IsLegacyCasPolicyEnabled || securityInfo == null);
#endif // FEATURE_CAS_POLICY

#pragma warning disable 618
            Assembly assembly = Assembly.LoadFrom(assemblyFile); //, securityInfo);
#pragma warning restore 618
            Type t = assembly.GetType(typeName, true, ignoreCase);

            object o = Activator.CreateInstance(t,
                                                bindingAttr,
                                                binder,
                                                args,
                                                culture,
                                                activationAttributes);

            // Log(o != null, "CreateInstanceFrom:: ", "Created Instance of class " + typeName, "Failed to create instance of class " + typeName);
            if (o == null)
                return null;
            else
            {
                ObjectHandle Handle = new ObjectHandle(o);
                return Handle;
            }
        }



        [ResourceExposure(ResourceScope.Machine)]
        [ResourceConsumption(ResourceScope.Machine)]
        private static ObjectHandle CreateInstanceFrom(string assemblyFile,
                                                     string typeName,
                                                     bool ignoreCase,
                                                     BindingFlags bindingAttr,
                                                     Binder binder,
                                                     object[] args,
                                                     Globalization.CultureInfo culture,
                                                     object[] activationAttributes)
        {
            return CreateInstanceFromInternal(assemblyFile,
                                              typeName,
                                              ignoreCase,
                                              bindingAttr,
                                              binder,
                                              args,
                                              culture,
                                              activationAttributes,
                                              null);
        }

        internal const BindingFlags ConstructorDefault = BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance;


        [ResourceExposure(ResourceScope.Machine)]
        [ResourceConsumption(ResourceScope.Machine)]
        private static ObjectHandle CreateInstanceFrom(String assemblyFile,
                                               String typeName,
                                               object[] activationAttributes)
        {
            return CreateInstanceFrom(assemblyFile,
                                      typeName,
                                      false,
                                      ConstructorDefault,
                                      null,
                                      null,
                                      null,
                                      activationAttributes);
        }


        [ResourceExposure(ResourceScope.Machine)]
        [ResourceConsumption(ResourceScope.Machine)]
        private static ObjectHandle CreateInstanceFrom(AppDomain appDomain, String assemblyFile, String typeName)
        {
            // the jit doesn't check for that, so we should 
            if (appDomain == null)
                throw new System.NullReferenceException();

            Diagnostics.Contracts.Contract.EndContractBlock();

            return CreateInstanceFrom(assemblyFile, typeName, null);
        }



        public static object CreateInstanceFromAndUnwrap(this AppDomain appDomain, string assemblyName, string typeName)
        {
            ObjectHandle oh = CreateInstanceFrom(appDomain, assemblyName, typeName);
            if (oh == null)
                return null;

            return oh.Unwrap();
        }
    }
}


namespace System.Runtime.InteropServices
{


    //
    // Zusammenfassung:
    //     Beschreibt die ursprünglichen Einstellungen von System.Runtime.InteropServices.TYPEFLAGS
    //     in der COM-Typbibliothek, aus der dieser Typ importiert wurde.
    [ComVisible(true)]
    [Flags]
    public enum TypeLibTypeFlags
    {
        //
        // Zusammenfassung:
        //     Ein Typbeschreibung, die ein Application-Objekt beschreibt.
        FAppObject = 1,
        //
        // Zusammenfassung:
        //     Instanzen des Typs können durch ITypeInfo::CreateInstance erstellt werden.
        FCanCreate = 2,
        //
        // Zusammenfassung:
        //     Der Typ ist lizenziert.
        FLicensed = 4,
        //
        // Zusammenfassung:
        //     Der Typ ist vordefiniert.Die Clientanwendung erstellt automatisch eine einzelne
        //     Instanz des Objekts, das über dieses Attribut verfügt.Der Name der auf das Objekt
        //     zeigenden Variablen ist derselbe wie der Klassenname des Objekts.
        FPreDeclId = 8,
        //
        // Zusammenfassung:
        //     Der Typ darf in Browsern nicht angezeigt werden.
        FHidden = 16,
        //
        // Zusammenfassung:
        //     Der Typ ist ein Steuerelement, aus dem andere Typen abgeleitet werden, und darf
        //     Benutzern nicht angezeigt werden.
        FControl = 32,
        //
        // Zusammenfassung:
        //     Die Schnittstelle stellt sowohl IDispatch als auch Vtable-Bindung bereit.
        FDual = 64,
        //
        // Zusammenfassung:
        //     Die Schnittstelle kann zur Laufzeit keine Member hinzufügen.
        FNonExtensible = 128,
        //
        // Zusammenfassung:
        //     Die in der Schnittstelle verwendeten Typen sind vollständig automatisierungskompatibel,
        //     wobei die Unterstützung von Vtable-Bindung eingeschlossen ist.
        FOleAutomation = 256,
        //
        // Zusammenfassung:
        //     Dieses Flag ist für Typen auf Systemebene oder für Typen bestimmt, die von Typenbrowsern
        //     nicht angezeigt werden sollen.
        FRestricted = 512,
        //
        // Zusammenfassung:
        //     Die Klasse unterstützt Aggregation.
        FAggregatable = 1024,
        //
        // Zusammenfassung:
        //     Das Objekt unterstützt IConnectionPointWithDefault und verfügt über Standardverhalten.
        FReplaceable = 2048,
        //
        // Zusammenfassung:
        //     Gibt an, dass die Schnittstelle direkt oder indirekt aus IDispatch abgeleitet
        //     ist.
        FDispatchable = 4096,
        //
        // Zusammenfassung:
        //     Gibt an, dass Basisschnittstellen vor dem Überprüfen von untergeordneten Schnittstellen
        //     auf Namensauflösung überprüft werden sollen.Dies ist die Umkehrung des Standardverhaltens.
        FReverseBind = 8192
    }


    //
    // Zusammenfassung:
    //     Enthält die ursprünglich für diesen Typ aus der COM-Typbibliothek importierten
    //     System.Runtime.InteropServices.TYPEFLAGS.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface, Inherited = false)]
    [ComVisible(true)]
    // The Tlbimp.exe(Type Library Importer) applies this attribute to classes or interfaces.
    // https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.typelibtypeattribute?view=netframework-4.8
    public sealed class TypeLibTypeAttrib : Attribute
    {

        private TypeLibTypeFlags m_flags;


        //
        // Zusammenfassung:
        //     Initialisiert eine neue Instanz der TypeLibTypeAttribute-Klasse mit dem angegebenen
        //     System.Runtime.InteropServices.TypeLibTypeFlags-Wert.
        //
        // Parameter:
        //   flags:
        //     Der System.Runtime.InteropServices.TypeLibTypeFlags-Wert für den attributierten
        //     Typ, wie er in der Typbibliothek angegeben ist, aus der er importiert wurde.
        public TypeLibTypeAttrib(TypeLibTypeFlags flags) => m_flags = flags;
        //
        // Zusammenfassung:
        //     Initialisiert eine neue Instanz der TypeLibTypeAttribute-Klasse mit dem angegebenen
        //     System.Runtime.InteropServices.TypeLibTypeFlags-Wert.
        //
        // Parameter:
        //   flags:
        //     Der System.Runtime.InteropServices.TypeLibTypeFlags-Wert für den attributierten
        //     Typ, wie er in der Typbibliothek angegeben ist, aus der er importiert wurde.
        public TypeLibTypeAttrib(short flags) => m_flags = (TypeLibTypeFlags)flags;

        //
        // Zusammenfassung:
        //     Ruft den System.Runtime.InteropServices.TypeLibTypeFlags-Wert für diesen Typ
        //     ab.
        //
        // Rückgabewerte:
        //     Der System.Runtime.InteropServices.TypeLibTypeFlags-Wert für diesen Typ.
        public TypeLibTypeFlags Value => m_flags;
    }
}