#region Licence
/*
MICROSOFT SOFTWARE LICENSE TERMS
MICROSOFT WINDOWS API CODE PACK FOR MICROSOFT .NET FRAMEWORK
___________________________________________________
These license terms are an agreement between Microsoft Corporation (or based on where you live, one of its affiliates) and you. Please read them. They apply to the software named above, which includes the media on which you received it, if any. The terms also apply to any Microsoft
• updates,
• supplements,
• Internet-based services, and 
• support services
for this software, unless other terms accompany those items. If so, those terms apply.
_______________________________________________________________________________________
BY USING THE SOFTWARE, YOU ACCEPT THESE TERMS. IF YOU DO NOT ACCEPT THEM, DO NOT USE THE SOFTWARE.
If you comply with these license terms, you have the rights below.
1. INSTALLATION AND USE RIGHTS. 
• You may use any number of copies of the software to design, develop and test your programs that run on a Microsoft Windows operating system.
• This agreement gives you rights to the software only. Any rights to a Microsoft Windows operating system (such as testing pre-release versions of Windows in a live operating environment) are provided separately by the license terms for Windows.
2. ADDITIONAL LICENSING REQUIREMENTS AND/OR USE RIGHTS.
a. Distributable Code. You may modify, copy, and distribute the software, in source or compiled form, to run on a Microsoft Windows operating system.
ii. Distribution Requirements. If you distribute the software, you must
• require distributors and external end users to agree to terms that protect it at least as much as this agreement; 
• if you modify the software and distribute such modified files, include prominent notices in such modified files so that recipients know that they are not receiving the original software;
• display your valid copyright notice on your programs; and
• indemnify, defend, and hold harmless Microsoft from any claims, including attorneys’ fees, related to the distribution or use of your programs or to your modifications to the software.
iii. Distribution Restrictions. You may not
• alter any copyright, trademark or patent notice in the software; 
• use Microsoft’s trademarks in your programs’ names or in a way that suggests your programs come from or are endorsed by Microsoft; 
• include the software in malicious, deceptive or unlawful programs; or
• modify or distribute the source code of the software so that any part of it becomes subject to an Excluded License. An Excluded License is one that requires, as a condition of use, modification or distribution, that
• the code be disclosed or distributed in source code form; or 
• others have the right to modify it.
3. SCOPE OF LICENSE. The software is licensed, not sold. This agreement only gives you some rights to use the software. Microsoft reserves all other rights. Unless applicable law gives you more rights despite this limitation, you may use the software only as expressly permitted in this agreement.
4. EXPORT RESTRICTIONS. The software is subject to United States export laws and regulations. You must comply with all domestic and international export laws and regulations that apply to the software. These laws include restrictions on destinations, end users and end use. For additional information, see <http://www.microsoft.com/exporting>.
5. SUPPORT SERVICES. Because this software is “as is,” we may not provide support services for it.
6. ENTIRE AGREEMENT. This agreement, and the terms for supplements, updates, Internet-based services and support services that you use, are the entire agreement for the software and support services.
7. APPLICABLE LAW.
a. United States. If you acquired the software in the United States, Washington state law governs the interpretation of this agreement and applies to claims for breach of it, regardless of conflict of laws principles. The laws of the state where you live govern all other claims, including claims under state consumer protection laws, unfair competition laws, and in tort.
b. Outside the United States. If you acquired the software in any other country, the laws of that country apply.
8. LEGAL EFFECT. This agreement describes certain legal rights. You may have other rights under the laws of your country. You may also have rights with respect to the party from whom you acquired the software. This agreement does not change your rights under the laws of your country if the laws of your country do not permit it to do so.
9. DISCLAIMER OF WARRANTY. THE SOFTWARE IS LICENSED “AS-IS.” YOU BEAR THE RISK OF USING IT. MICROSOFT GIVES NO EXPRESS WARRANTIES, GUARANTEES OR CONDITIONS. YOU MAY HAVE ADDITIONAL CONSUMER RIGHTS UNDER YOUR LOCAL LAWS WHICH THIS AGREEMENT CANNOT CHANGE. TO THE EXTENT PERMITTED UNDER YOUR LOCAL LAWS, MICROSOFT EXCLUDES THE IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT.
10. LIMITATION ON AND EXCLUSION OF REMEDIES AND DAMAGES. YOU CAN RECOVER FROM MICROSOFT AND ITS SUPPLIERS ONLY DIRECT DAMAGES UP TO U.S. $5.00. YOU CANNOT RECOVER ANY OTHER DAMAGES, INCLUDING CONSEQUENTIAL, LOST PROFITS, SPECIAL, INDIRECT OR INCIDENTAL DAMAGES.
This limitation applies to
• anything related to the software, services, content (including code) on third party Internet sites, or third party programs; and
• claims for breach of contract, breach of warranty, guarantee or condition, strict liability, negligence, or other tort to the extent permitted by applicable law.
It also applies even if Microsoft knew or should have known about the possibility of the damages. The above limitation or exclusion may not apply to you because your country may not allow the exclusion or limitation of incidental, consequential or other damages.
Please note: As this software is distributed in Quebec, Canada, some of the clauses in this agreement are provided below in French.
Remarque : Ce logiciel étant distribué au Québec, Canada, certaines des clauses dans ce contrat sont fournies ci-dessous en français.
EXONÉRATION DE GARANTIE. Le logiciel visé par une licence est offert « tel quel ». Toute utilisation de ce logiciel est à votre seule risque et péril. Microsoft n’accorde aucune autre garantie expresse. Vous pouvez bénéficier de droits additionnels en vertu du droit local sur la protection des consommateurs, que ce contrat ne peut modifier. La ou elles sont permises par le droit locale, les garanties implicites de qualité marchande, d’adéquation à un usage particulier et d’absence de contrefaçon sont exclues.
LIMITATION DES DOMMAGES-INTÉRÊTS ET EXCLUSION DE RESPONSABILITÉ POUR LES DOMMAGES. Vous pouvez obtenir de Microsoft et de ses fournisseurs une indemnisation en cas de dommages directs uniquement à hauteur de 5,00 $ US. Vous ne pouvez prétendre à aucune indemnisation pour les autres dommages, y compris les dommages spéciaux, indirects ou accessoires et pertes de bénéfices.
Cette limitation concerne :
• tout ce qui est relié au logiciel, aux services ou au contenu (y compris le code) figurant sur des sites Internet tiers ou dans des programmes tiers ; et
• les réclamations au titre de violation de contrat ou de garantie, ou au titre de responsabilité stricte, de négligence ou d’une autre faute dans la limite autorisée par la loi en vigueur.
Elle s’applique également, même si Microsoft connaissait ou devrait connaître l’éventualité d’un tel dommage. Si votre pays n’autorise pas l’exclusion ou la limitation de responsabilité pour les dommages indirects, accessoires ou de quelque nature que ce soit, il se peut que la limitation ou l’exclusion ci-dessus ne s’appliquera pas à votre égard.
EFFET JURIDIQUE. Le présent contrat décrit certains droits juridiques. Vous pourriez avoir d’autres droits prévus par les lois de votre pays. Le présent contrat ne modifie pas les droits que vous confèrent les lois de votre pays si celles-ci ne le permettent pas.
*/
#endregion

using Microsoft.Windows.API.Code.Pack.Dialogs.Resources;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Microsoft.Windows.API.Code.Pack.Dialogs
{
    /// <summary>
    /// Strongly typed collection for dialog controls.
    /// </summary>
    /// <typeparam name="T">DialogControl</typeparam>
    public sealed class DialogControlCollection<T> : Collection<T> where T : DialogControl
    {
        private IDialogControlHost hostingDialog;

        internal DialogControlCollection(IDialogControlHost host)
        {
            hostingDialog = host;
        }

        /// <summary>
        /// Inserts an dialog control at the specified index.
        /// </summary>
        /// <param name="index">The location to insert the control.</param>
        /// <param name="control">The item to insert.</param>
        /// <permission cref="System.InvalidOperationException">A control with 
        /// the same name already exists in this collection -or- 
        /// the control is being hosted by another dialog -or- the associated dialog is 
        /// showing and cannot be modified.</permission>
        protected override void InsertItem(int index, T control)
        {
            // Check for duplicates, lack of host, 
            // and during-show adds.
            if (Items.Contains(control))
            {
                throw new InvalidOperationException(LocalizedMessages.DialogCollectionCannotHaveDuplicateNames);
            }
            if (control.HostingDialog != null)
            {
                throw new InvalidOperationException(LocalizedMessages.DialogCollectionControlAlreadyHosted);
            }
            if (!hostingDialog.IsCollectionChangeAllowed())
            {
                throw new InvalidOperationException(LocalizedMessages.DialogCollectionModifyShowingDialog);
            }

            // Reparent, add control.
            control.HostingDialog = hostingDialog;
            base.InsertItem(index, control);

            // Notify that we've added a control.
            hostingDialog.ApplyCollectionChanged();
        }

        /// <summary>
        /// Removes the control at the specified index.
        /// </summary>
        /// <param name="index">The location of the control to remove.</param>
        /// <permission cref="System.InvalidOperationException">
        /// The associated dialog is 
        /// showing and cannot be modified.</permission>
        protected override void RemoveItem(int index)
        {
            // Notify that we're about to remove a control.
            // Throw if dialog showing.
            if (!hostingDialog.IsCollectionChangeAllowed())
            {
                throw new InvalidOperationException(LocalizedMessages.DialogCollectionModifyShowingDialog);
            }

            DialogControl control = (DialogControl)Items[index];

            // Unparent and remove.
            control.HostingDialog = null;
            base.RemoveItem(index);

            hostingDialog.ApplyCollectionChanged();
        }

        /// <summary>
        /// Defines the indexer that supports accessing controls by name. 
        /// </summary>
        /// <remarks>
        /// <para>Control names are case sensitive.</para>
        /// <para>This indexer is useful when the dialog is created in XAML
        /// rather than constructed in code.</para></remarks>
        ///<exception cref="System.ArgumentException">
        /// The name cannot be null or a zero-length string.</exception>
        /// <remarks>If there is more than one control with the same name, only the <B>first control</B> will be returned.</remarks>
        public T this[string name]
        {
            get
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException(LocalizedMessages.DialogCollectionControlNameNull, "name");
                }

                return Items.FirstOrDefault(x => x.Name == name);
            }
        }

        /// <summary>
        /// Searches for the control who's id matches the value
        /// passed in the <paramref name="id"/> parameter.
        /// </summary>
        /// 
        /// <param name="id">An integer containing the identifier of the 
        /// control being searched for.</param>
        /// 
        /// <returns>A DialogControl who's id matches the value of the
        /// <paramref name="id"/> parameter.</returns>        
        internal DialogControl GetControlbyId(int id)
        {
            return Items.FirstOrDefault(x => x.Id == id);
        }
    }
}