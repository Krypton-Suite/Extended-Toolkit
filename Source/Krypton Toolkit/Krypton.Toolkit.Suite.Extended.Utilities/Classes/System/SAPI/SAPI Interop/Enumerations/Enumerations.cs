#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    internal enum SapiConfidenceLevels
    {
        SP_LOW_CONFIDENCE = -1,
        SP_NORMAL_CONFIDENCE,
        SP_HIGH_CONFIDENCE
    }

    internal enum SAPIErrorCodes
    {
        S_OK = 0,
        S_FALSE = 1,
        SP_NO_RULE_ACTIVE = 282709,
        SP_NO_RULES_TO_ACTIVATE = 282747,
        S_LIMIT_REACHED = 282751,
        E_FAIL = -2147467259,
        SP_NO_PARSE_FOUND = 282668,
        SP_WORD_EXISTS_WITHOUT_PRONUNCIATION = 282679,
        SPERR_FIRST = -2147201023,
        SPERR_LAST = -2147200890,
        STG_E_FILENOTFOUND = -2147287038,
        CLASS_E_CLASSNOTAVAILABLE = -2147221231,
        REGDB_E_CLASSNOTREG = -2147221164,
        SPERR_UNSUPPORTED_FORMAT = -2147201021,
        SPERR_UNSUPPORTED_PHONEME = -2147200902,
        SPERR_VOICE_NOT_FOUND = -2147200877,
        SPERR_NOT_IN_LEX = -2147200999,
        SPERR_TOO_MANY_GRAMMARS = -2147200990,
        SPERR_INVALID_IMPORT = -2147200988,
        SPERR_STREAM_CLOSED = -2147200968,
        SPERR_NO_MORE_ITEMS = -2147200967,
        SPERR_NOT_FOUND = -2147200966,
        SPERR_NOT_TOPLEVEL_RULE = -2147200940,
        SPERR_SHARED_ENGINE_DISABLED = -2147200906,
        SPERR_RECOGNIZER_NOT_FOUND = -2147200905,
        SPERR_AUDIO_NOT_FOUND = -2147200904,
        SPERR_NOT_SUPPORTED_FOR_INPROC_RECOGNIZER = -2147200893,
        SPERR_LEX_INVALID_DATA = -2147200891,
        SPERR_CFG_INVALID_DATA = -2147200890
    }

    internal enum SPADAPTATIONRELEVANCE
    {
        SPAR_Unknown,
        SPAR_Low,
        SPAR_Medium,
        SPAR_High
    }

    [Flags]
    internal enum SPADAPTATIONSETTINGS
    {
        SPADS_Default = 0x0,
        SPADS_CurrentRecognizer = 0x1,
        SPADS_RecoProfile = 0x2,
        SPADS_Immediate = 0x4,
        SPADS_Reset = 0x8
    }

    internal enum SPAUDIOOPTIONS
    {
        SPAO_NONE,
        SPAO_RETAIN_AUDIO
    }

    internal enum SPAUDIOSTATE
    {
        SPAS_CLOSED,
        SPAS_STOP,
        SPAS_PAUSE,
        SPAS_RUN
    }

    [Flags]
    internal enum SPBOOKMARKOPTIONS
    {
        SPBO_NONE = 0x0,
        SPBO_PAUSE = 0x1,
        SPBO_AHEAD = 0x2,
        SPBO_TIME_UNITS = 0x4
    }

    internal enum SPCATEGORYSTATE
    {
        SPCAS_ENABLED,
        SPCAS_DISABLED
    }

    internal enum SPCATEGORYTYPE
    {
        SPCT_COMMAND,
        SPCT_DICTATION,
        SPCT_SUB_COMMAND,
        SPCT_SUB_DICTATION
    }

    [Flags]
    internal enum SPCOMMITFLAGS
    {
        SPCF_NONE = 0x0,
        SPCF_ADD_TO_USER_LEXICON = 0x1,
        SPCF_DEFINITE_CORRECTION = 0x2
    }

    internal enum SPCONTEXTSTATE
    {
        SPCS_DISABLED,
        SPCS_ENABLED
    }

    [Flags]
    internal enum SPDISPLAYATTRIBUTES
    {
        SPAF_ZERO_TRAILING_SPACE = 0x0,
        SPAF_ONE_TRAILING_SPACE = 0x2,
        SPAF_TWO_TRAILING_SPACES = 0x4,
        SPAF_CONSUME_LEADING_SPACES = 0x8,
        SPAF_USER_SPECIFIED = 0x80
    }

    [Flags]
    internal enum SPEAKFLAGS
    {
        SPF_DEFAULT = 0x0,
        SPF_ASYNC = 0x1,
        SPF_PURGEBEFORESPEAK = 0x2,
        SPF_IS_FILENAME = 0x4,
        SPF_IS_XML = 0x8,
        SPF_IS_NOT_XML = 0x10,
        SPF_PERSIST_XML = 0x20,
        SPF_NLP_SPEAK_PUNC = 0x40,
        SPF_PARSE_SAPI = 0x80,
        SPF_PARSE_SSML = 0x100
    }

    [Flags]
    internal enum SpeechEmulationCompareFlags
    {
        SECFIgnoreCase = 0x1,
        SECFIgnoreKanaType = 0x10000,
        SECFIgnoreWidth = 0x20000,
        SECFNoSpecialChars = 0x20000000,
        SECFEmulateResult = 0x40000000,
        SECFDefault = 0x30001
    }

    internal enum SpeechRunState
    {
        SPRS_DONE,
        SPRS_IS_SPEAKING
    }

    [Flags]
    internal enum SPENDSRSTREAMFLAGS
    {
        SPESF_NONE = 0x0,
        SPESF_STREAM_RELEASED = 0x1,
        SPESF_EMULATED = 0x2
    }

    internal enum SPEVENTENUM : ushort
    {
        SPEI_UNDEFINED = 0,
        SPEI_START_INPUT_STREAM = 1,
        SPEI_END_INPUT_STREAM = 2,
        SPEI_VOICE_CHANGE = 3,
        SPEI_TTS_BOOKMARK = 4,
        SPEI_WORD_BOUNDARY = 5,
        SPEI_PHONEME = 6,
        SPEI_SENTENCE_BOUNDARY = 7,
        SPEI_VISEME = 8,
        SPEI_TTS_AUDIO_LEVEL = 9,
        SPEI_TTS_PRIVATE = 0xF,
        SPEI_MIN_TTS = 1,
        SPEI_MAX_TTS = 0xF,
        SPEI_END_SR_STREAM = 34,
        SPEI_SOUND_START = 35,
        SPEI_SOUND_END = 36,
        SPEI_PHRASE_START = 37,
        SPEI_RECOGNITION = 38,
        SPEI_HYPOTHESIS = 39,
        SPEI_SR_BOOKMARK = 40,
        SPEI_PROPERTY_NUM_CHANGE = 41,
        SPEI_PROPERTY_STRING_CHANGE = 42,
        SPEI_FALSE_RECOGNITION = 43,
        SPEI_INTERFERENCE = 44,
        SPEI_REQUEST_UI = 45,
        SPEI_RECO_STATE_CHANGE = 46,
        SPEI_ADAPTATION = 47,
        SPEI_START_SR_STREAM = 48,
        SPEI_RECO_OTHER_CONTEXT = 49,
        SPEI_SR_AUDIO_LEVEL = 50,
        SPEI_SR_RETAINEDAUDIO = 51,
        SPEI_SR_PRIVATE = 52,
        SPEI_ACTIVE_CATEGORY_CHANGED = 53,
        SPEI_TEXTFEEDBACK = 54,
        SPEI_RECOGNITION_ALL = 55,
        SPEI_BARGE_IN = 56,
        SPEI_RESERVED1 = 30,
        SPEI_RESERVED2 = 33,
        SPEI_RESERVED3 = 0x3F
    }

    internal enum SPEVENTLPARAMTYPE : ushort
    {
        SPET_LPARAM_IS_UNDEFINED,
        SPET_LPARAM_IS_TOKEN,
        SPET_LPARAM_IS_OBJECT,
        SPET_LPARAM_IS_POINTER,
        SPET_LPARAM_IS_STRING
    }

    internal enum SPFILEMODE
    {
        SPFM_OPEN_READONLY = 0,
        SPFM_CREATE_ALWAYS = 3
    }

    internal enum SPGRAMMAROPTIONS
    {
        SPGO_SAPI = 1,
        SPGO_SRGS = 2,
        SPGO_UPS = 4,
        SPGO_SRGS_MSS_SCRIPT = 8,
        SPGO_FILE = 0x10,
        SPGO_HTTP = 0x20,
        SPGO_RES = 0x40,
        SPGO_OBJECT = 0x80,
        SPGO_SRGS_W3C_SCRIPT = 0x100,
        SPGO_SRGS_STG_SCRIPT = 0x200,
        SPGO_SRGS_SCRIPT = 778,
        SPGO_DEFAULT = 243,
        SPGO_ALL = 1019
    }

    internal enum SPGRAMMARSTATE
    {
        SPGS_DISABLED = 0,
        SPGS_ENABLED = 1,
        SPGS_EXCLUSIVE = 3
    }

    internal enum SPINTERFERENCE
    {
        SPINTERFERENCE_NONE,
        SPINTERFERENCE_NOISE,
        SPINTERFERENCE_NOSIGNAL,
        SPINTERFERENCE_TOOLOUD,
        SPINTERFERENCE_TOOQUIET,
        SPINTERFERENCE_TOOFAST,
        SPINTERFERENCE_TOOSLOW
    }

    internal enum SPLOADOPTIONS
    {
        SPLO_STATIC,
        SPLO_DYNAMIC
    }

    [Flags]
    internal enum SPRECOEVENTFLAGS
    {
        SPREF_AutoPause = 0x1,
        SPREF_Emulated = 0x2,
        SPREF_SMLTimeout = 0x4,
        SPREF_ExtendableParse = 0x8,
        SPREF_ReSent = 0x10,
        SPREF_Hypothesis = 0x20,
        SPREF_FalseRecognition = 0x40
    }

    internal enum SPRECOSTATE
    {
        SPRST_INACTIVE,
        SPRST_ACTIVE,
        SPRST_ACTIVE_ALWAYS,
        SPRST_INACTIVE_WITH_PURGE,
        SPRST_NUM_STATES
    }

    [Flags]
    internal enum SPRESULTALPHABET
    {
        SPRA_NONE = 0x0,
        SPRA_APP_UPS = 0x1,
        SPRA_ENGINE_UPS = 0x2
    }

    internal enum SPRULESTATE
    {
        SPRS_INACTIVE = 0,
        SPRS_ACTIVE = 1,
        SPRS_ACTIVE_WITH_AUTO_PAUSE = 3,
        SPRS_ACTIVE_USER_DELIMITED = 4
    }

    internal enum SPSTREAMFORMATTYPE
    {
        SPWF_INPUT,
        SPWF_SRENGINE
    }

    internal enum SPVPRIORITY
    {
        SPVPRI_NORMAL,
        SPVPRI_ALERT,
        SPVPRI_OVER
    }

    internal enum SPXMLRESULTOPTIONS
    {
        SPXRO_SML,
        SPXRO_Alternates_SML
    }
}