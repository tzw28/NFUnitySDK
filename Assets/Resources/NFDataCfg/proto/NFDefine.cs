// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: NFDefine.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace NFMsg {

  /// <summary>Holder for reflection information generated from NFDefine.proto</summary>
  public static partial class NFDefineReflection {

    #region Descriptor
    /// <summary>File descriptor for NFDefine.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static NFDefineReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg5ORkRlZmluZS5wcm90bxIFTkZNc2cqggQKDkVHYW1lRXZlbnRDb2RlEgsK",
            "B1NVQ0NFU1MQABIQCgxVTktPV05fRVJST1IQARIRCg1BQ0NPVU5UX0VYSVNU",
            "EAISFgoSQUNDT1VOVFBXRF9JTlZBTElEEAMSEQoNQUNDT1VOVF9VU0lORxAE",
            "EhIKDkFDQ09VTlRfTE9DS0VEEAUSGQoVQUNDT1VOVF9MT0dJTl9TVUNDRVNT",
            "EAYSFgoSVkVSSUZZX0tFWV9TVUNDRVNTEAcSEwoPVkVSSUZZX0tFWV9GQUlM",
            "EAgSGAoUU0VMRUNUU0VSVkVSX1NVQ0NFU1MQCRIVChFTRUxFQ1RTRVJWRVJf",
            "RkFJTBAKEhMKD0NIQVJBQ1RFUl9FWElTVBBuEhUKEVNWUlpPTkVJRF9JTlZB",
            "TElEEG8SFAoQQ0hBUkFDVEVSX05VTU9VVBBwEhUKEUNIQVJBQ1RFUl9JTlZB",
            "TElEEHESFgoSQ0hBUkFDVEVSX05PVEVYSVNUEHISEwoPQ0hBUkFDVEVSX1VT",
            "SU5HEHMSFAoQQ0hBUkFDVEVSX0xPQ0tFRBB0EhEKDVpPTkVfT1ZFUkxPQUQQ",
            "dRIOCgpOT1RfT05MSU5FEHYSGQoUSU5TVUZGSUNJRU5UX0RJQU1PTkQQyAES",
            "FgoRSU5TVUZGSUNJRU5UX0dPTEQQyQESFAoPSU5TVUZGSUNJRU5UX1NQEMoB",
            "KssRCgpFR2FtZU1zZ0lEEgoKBlVOS05PVxAAEhAKDEVWRU5UX1JFU1VMVBAB",
            "EhMKD0VWRU5UX1RSQU5TUE9SVBACEhAKDENMT1NFX1NPQ0tFVBADEhgKFFdU",
            "TV9XT1JMRF9SRUdJU1RFUkVEEAoSGgoWV1RNX1dPUkxEX1VOUkVHSVNURVJF",
            "RBALEhUKEVdUTV9XT1JMRF9SRUZSRVNIEAwSGAoUTFRNX0xPR0lOX1JFR0lT",
            "VEVSRUQQFBIaChZMVE1fTE9HSU5fVU5SRUdJU1RFUkVEEBUSFQoRTFRNX0xP",
            "R0lOX1JFRlJFU0gQFhIZChVQVFdHX1BST1hZX1JFR0lTVEVSRUQQHhIbChdQ",
            "VFdHX1BST1hZX1VOUkVHSVNURVJFRBAfEhYKElBUV0dfUFJPWFlfUkVGUkVT",
            "SBAgEhcKE0dUV19HQU1FX1JFR0lTVEVSRUQQKBIZChVHVFdfR0FNRV9VTlJF",
            "R0lTVEVSRUQQKRIUChBHVFdfR0FNRV9SRUZSRVNIECoSFQoRRFRXX0RCX1JF",
            "R0lTVEVSRUQQPBIXChNEVFdfREJfVU5SRUdJU1RFUkVEED0SEgoORFRXX0RC",
            "X1JFRlJFU0gQPhIQCgxTVFNfTkVUX0lORk8QRhIQCgxSRVFfTEFHX1RFU1QQ",
            "UBIVChFBQ0tfR0FURV9MQUdfVEVTVBBREhUKEUFDS19HQU1FX0xBR19URVNU",
            "EFISFQoRU1RTX1NFUlZFUl9SRVBPUlQQWhISCg5TVFNfSEVBUlRfQkVBVBBk",
            "Eg0KCVJFUV9MT0dJThBlEg0KCUFDS19MT0dJThBmEg4KClJFUV9MT0dPVVQQ",
            "ZxISCg5SRVFfV09STERfTElTVBBuEhIKDkFDS19XT1JMRF9MSVNUEG8SFQoR",
            "UkVRX0NPTk5FQ1RfV09STEQQcBIVChFBQ0tfQ09OTkVDVF9XT1JMRBBxEhkK",
            "FVJFUV9LSUNLRURfRlJPTV9XT1JMRBByEhMKD1JFUV9DT05ORUNUX0tFWRB4",
            "EhMKD0FDS19DT05ORUNUX0tFWRB6EhYKEVJFUV9TRUxFQ1RfU0VSVkVSEIIB",
            "EhYKEUFDS19TRUxFQ1RfU0VSVkVSEIMBEhIKDVJFUV9ST0xFX0xJU1QQhAES",
            "EgoNQUNLX1JPTEVfTElTVBCFARIUCg9SRVFfQ1JFQVRFX1JPTEUQhgESFAoP",
            "UkVRX0RFTEVURV9ST0xFEIcBEhUKEFJFUV9SRUNPVkVSX1JPTEUQiAESFwoS",
            "UkVRX0xPQURfUk9MRV9EQVRBEIwBEhcKEkFDS19MT0FEX1JPTEVfREFUQRCN",
            "ARIXChJSRVFfU0FWRV9ST0xFX0RBVEEQjgESFwoSQUNLX1NBVkVfUk9MRV9E",
            "QVRBEI8BEhMKDlJFUV9FTlRFUl9HQU1FEJYBEhMKDkFDS19FTlRFUl9HQU1F",
            "EJcBEhMKDlJFUV9MRUFWRV9HQU1FEJgBEhMKDkFDS19MRUFWRV9HQU1FEJkB",
            "EhMKDlJFUV9TV0FQX1NDRU5FEJsBEhMKDkFDS19TV0FQX1NDRU5FEJwBEhgK",
            "E1JFUV9TV0FQX0hPTUVfU0NFTkUQnQESGAoTQUNLX1NXQVBfSE9NRV9TQ0VO",
            "RRCeARIaChVSRVFfRU5URVJfR0FNRV9GSU5JU0gQnwESGgoVQUNLX0VOVEVS",
            "X0dBTUVfRklOSVNIEKABEhUKEEFDS19PQkpFQ1RfRU5UUlkQyAESFQoQQUNL",
            "X09CSkVDVF9MRUFWRRDJARIeChlBQ0tfT0JKRUNUX1BST1BFUlRZX0VOVFJZ",
            "EMoBEhwKF0FDS19PQkpFQ1RfUkVDT1JEX0VOVFJZEMsBEhUKEEFDS19QUk9Q",
            "RVJUWV9JTlQQ0gESFwoSQUNLX1BST1BFUlRZX0ZMT0FUENMBEhgKE0FDS19Q",
            "Uk9QRVJUWV9TVFJJTkcQ1AESGAoTQUNLX1BST1BFUlRZX09CSkVDVBDWARIZ",
            "ChRBQ0tfUFJPUEVSVFlfVkVDVE9SMhDXARIZChRBQ0tfUFJPUEVSVFlfVkVD",
            "VE9SMxDYARIXChJBQ0tfUFJPUEVSVFlfQ0xFQVIQ2QESEAoLQUNLX0FERF9S",
            "T1cQ3AESEwoOQUNLX1JFTU9WRV9ST1cQ3QESEQoMQUNLX1NXQVBfUk9XEN4B",
            "EhMKDkFDS19SRUNPUkRfSU5UEN8BEhUKEEFDS19SRUNPUkRfRkxPQVQQ4AES",
            "FgoRQUNLX1JFQ09SRF9TVFJJTkcQ4gESFgoRQUNLX1JFQ09SRF9PQkpFQ1QQ",
            "4wESFwoSQUNLX1JFQ09SRF9WRUNUT1IyEOQBEhcKEkFDS19SRUNPUkRfVkVD",
            "VE9SMxDlARIVChBBQ0tfUkVDT1JEX0NMRUFSEPoBEhQKD0FDS19SRUNPUkRf",
            "U09SVBD7ARIWChFBQ0tfREFUQV9GSU5JU0hFRBCEAhINCghSRVFfTU9WRRCs",
            "AhINCghBQ0tfTU9WRRCtAhINCghSRVFfQ0hBVBDeAhINCghBQ0tfQ0hBVBDf",
            "AhIWChFSRVFfU0tJTExfT0JKRUNUWBCQAxIWChFBQ0tfU0tJTExfT0JKRUNU",
            "WBCRAxISCg1SRVFfU0tJTExfUE9TEJIDEhIKDUFDS19TS0lMTF9QT1MQkwMS",
            "EgoNUkVRX01PREVMX1JBVxD0AxISCg1BQ0tfTU9ERUxfUkFXEPUDEhgKE1JF",
            "UV9NT0RFTF9JTkZPX0xJU1QQ9gMSGAoTQUNLX01PREVMX0lORk9fTElTVBD3",
            "AxIVChBSRVFfTU9ERUxfVEFSR0VUEPgDEhUKEEFDS19NT0RFTF9UQVJHRVQQ",
            "+QMSFQoQUkVRX01PREVMX1NXSVRDSBD6AxIVChBBQ0tfTU9ERUxfU1dJVENI",
            "EPsDEhMKDlJFUV9NT0RFTF9WSUVXEIgEEhMKDkFDS19NT0RFTF9WSUVXEIkE",
            "EhYKEUFDS19PTkxJTkVfTk9USUZZENgEEhcKEkFDS19PRkZMSU5FX05PVElG",
            "WRDZBCpHCglFSXRlbVR5cGUSDQoJRUlUX0VRVUlQEAASCwoHRUlUX0dFTRAB",
            "Eg4KCkVJVF9TVVBQTFkQAhIOCgpFSVRfU0NST0xMEAMqtwEKCkVTa2lsbFR5",
            "cGUSFgoSQlJJRUZfU0lOR0xFX1NLSUxMEAASFQoRQlJJRUZfR1JPVVBfU0tJ",
            "TEwQARIXChNCVUxMRVRfU0lOR0xFX1NLSUxMEAISGAoUQlVMTEVUX1JFQk9V",
            "TkRfU0tJTEwQAxIcChhCVUxMRVRfVEFSR0VUX0JPTUJfU0tJTEwQBBIZChVC",
            "VUxMRVRfUE9TX0JPTUJfU0tJTEwQBRIOCgpGVU5DX1NLSUxMEAYqTQoKRVNj",
            "ZW5lVHlwZRIQCgxOT1JNQUxfU0NFTkUQABIWChJTSU5HTEVfQ0xPTkVfU0NF",
            "TkUQARIVChFNVUxUSV9DTE9ORV9TQ0VORRACKkYKCEVOUENUeXBlEg4KCk5P",
            "Uk1BTF9OUEMQABIMCghIRVJPX05QQxABEg4KClRVUlJFVF9OUEMQAhIMCghG",
            "VU5DX05QQxADYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::NFMsg.EGameEventCode), typeof(global::NFMsg.EGameMsgID), typeof(global::NFMsg.EItemType), typeof(global::NFMsg.ESkillType), typeof(global::NFMsg.ESceneType), typeof(global::NFMsg.ENPCType), }, null, null));
    }
    #endregion

  }
  #region Enums
  /// <summary>
  ///events
  /// </summary>
  public enum EGameEventCode {
    /// <summary>
    /// </summary>
    [pbr::OriginalName("SUCCESS")] Success = 0,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("UNKOWN_ERROR")] UnkownError = 1,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("ACCOUNT_EXIST")] AccountExist = 2,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("ACCOUNTPWD_INVALID")] AccountpwdInvalid = 3,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("ACCOUNT_USING")] AccountUsing = 4,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("ACCOUNT_LOCKED")] AccountLocked = 5,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("ACCOUNT_LOGIN_SUCCESS")] AccountLoginSuccess = 6,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("VERIFY_KEY_SUCCESS")] VerifyKeySuccess = 7,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("VERIFY_KEY_FAIL")] VerifyKeyFail = 8,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("SELECTSERVER_SUCCESS")] SelectserverSuccess = 9,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("SELECTSERVER_FAIL")] SelectserverFail = 10,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("CHARACTER_EXIST")] CharacterExist = 110,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("SVRZONEID_INVALID")] SvrzoneidInvalid = 111,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("CHARACTER_NUMOUT")] CharacterNumout = 112,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("CHARACTER_INVALID")] CharacterInvalid = 113,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("CHARACTER_NOTEXIST")] CharacterNotexist = 114,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("CHARACTER_USING")] CharacterUsing = 115,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("CHARACTER_LOCKED")] CharacterLocked = 116,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("ZONE_OVERLOAD")] ZoneOverload = 117,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("NOT_ONLINE")] NotOnline = 118,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("INSUFFICIENT_DIAMOND")] InsufficientDiamond = 200,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("INSUFFICIENT_GOLD")] InsufficientGold = 201,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("INSUFFICIENT_SP")] InsufficientSp = 202,
  }

  public enum EGameMsgID {
    /// <summary>
    /// </summary>
    [pbr::OriginalName("UNKNOW")] Unknow = 0,
    /// <summary>
    /// for events
    /// </summary>
    [pbr::OriginalName("EVENT_RESULT")] EventResult = 1,
    /// <summary>
    /// for events
    /// </summary>
    [pbr::OriginalName("EVENT_TRANSPORT")] EventTransport = 2,
    /// <summary>
    /// want to close some one
    /// </summary>
    [pbr::OriginalName("CLOSE_SOCKET")] CloseSocket = 3,
    [pbr::OriginalName("WTM_WORLD_REGISTERED")] WtmWorldRegistered = 10,
    [pbr::OriginalName("WTM_WORLD_UNREGISTERED")] WtmWorldUnregistered = 11,
    [pbr::OriginalName("WTM_WORLD_REFRESH")] WtmWorldRefresh = 12,
    [pbr::OriginalName("LTM_LOGIN_REGISTERED")] LtmLoginRegistered = 20,
    [pbr::OriginalName("LTM_LOGIN_UNREGISTERED")] LtmLoginUnregistered = 21,
    [pbr::OriginalName("LTM_LOGIN_REFRESH")] LtmLoginRefresh = 22,
    [pbr::OriginalName("PTWG_PROXY_REGISTERED")] PtwgProxyRegistered = 30,
    [pbr::OriginalName("PTWG_PROXY_UNREGISTERED")] PtwgProxyUnregistered = 31,
    [pbr::OriginalName("PTWG_PROXY_REFRESH")] PtwgProxyRefresh = 32,
    [pbr::OriginalName("GTW_GAME_REGISTERED")] GtwGameRegistered = 40,
    [pbr::OriginalName("GTW_GAME_UNREGISTERED")] GtwGameUnregistered = 41,
    [pbr::OriginalName("GTW_GAME_REFRESH")] GtwGameRefresh = 42,
    [pbr::OriginalName("DTW_DB_REGISTERED")] DtwDbRegistered = 60,
    [pbr::OriginalName("DTW_DB_UNREGISTERED")] DtwDbUnregistered = 61,
    [pbr::OriginalName("DTW_DB_REFRESH")] DtwDbRefresh = 62,
    [pbr::OriginalName("STS_NET_INFO")] StsNetInfo = 70,
    [pbr::OriginalName("REQ_LAG_TEST")] ReqLagTest = 80,
    [pbr::OriginalName("ACK_GATE_LAG_TEST")] AckGateLagTest = 81,
    [pbr::OriginalName("ACK_GAME_LAG_TEST")] AckGameLagTest = 82,
    [pbr::OriginalName("STS_SERVER_REPORT")] StsServerReport = 90,
    [pbr::OriginalName("STS_HEART_BEAT")] StsHeartBeat = 100,
    /// <summary>
    ///////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    [pbr::OriginalName("REQ_LOGIN")] ReqLogin = 101,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("ACK_LOGIN")] AckLogin = 102,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("REQ_LOGOUT")] ReqLogout = 103,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("REQ_WORLD_LIST")] ReqWorldList = 110,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("ACK_WORLD_LIST")] AckWorldList = 111,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("REQ_CONNECT_WORLD")] ReqConnectWorld = 112,
    [pbr::OriginalName("ACK_CONNECT_WORLD")] AckConnectWorld = 113,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("REQ_KICKED_FROM_WORLD")] ReqKickedFromWorld = 114,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("REQ_CONNECT_KEY")] ReqConnectKey = 120,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("ACK_CONNECT_KEY")] AckConnectKey = 122,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("REQ_SELECT_SERVER")] ReqSelectServer = 130,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("ACK_SELECT_SERVER")] AckSelectServer = 131,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("REQ_ROLE_LIST")] ReqRoleList = 132,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("ACK_ROLE_LIST")] AckRoleList = 133,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("REQ_CREATE_ROLE")] ReqCreateRole = 134,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("REQ_DELETE_ROLE")] ReqDeleteRole = 135,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("REQ_RECOVER_ROLE")] ReqRecoverRole = 136,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("REQ_LOAD_ROLE_DATA")] ReqLoadRoleData = 140,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("ACK_LOAD_ROLE_DATA")] AckLoadRoleData = 141,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("REQ_SAVE_ROLE_DATA")] ReqSaveRoleData = 142,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("ACK_SAVE_ROLE_DATA")] AckSaveRoleData = 143,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("REQ_ENTER_GAME")] ReqEnterGame = 150,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("ACK_ENTER_GAME")] AckEnterGame = 151,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("REQ_LEAVE_GAME")] ReqLeaveGame = 152,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("ACK_LEAVE_GAME")] AckLeaveGame = 153,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("REQ_SWAP_SCENE")] ReqSwapScene = 155,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("ACK_SWAP_SCENE")] AckSwapScene = 156,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("REQ_SWAP_HOME_SCENE")] ReqSwapHomeScene = 157,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("ACK_SWAP_HOME_SCENE")] AckSwapHomeScene = 158,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("REQ_ENTER_GAME_FINISH")] ReqEnterGameFinish = 159,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("ACK_ENTER_GAME_FINISH")] AckEnterGameFinish = 160,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("ACK_OBJECT_ENTRY")] AckObjectEntry = 200,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("ACK_OBJECT_LEAVE")] AckObjectLeave = 201,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("ACK_OBJECT_PROPERTY_ENTRY")] AckObjectPropertyEntry = 202,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("ACK_OBJECT_RECORD_ENTRY")] AckObjectRecordEntry = 203,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("ACK_PROPERTY_INT")] AckPropertyInt = 210,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("ACK_PROPERTY_FLOAT")] AckPropertyFloat = 211,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("ACK_PROPERTY_STRING")] AckPropertyString = 212,
    /// <summary>
    ///EGMI_ACK_PROPERTY_DOUBLE				= 213;			//
    /// </summary>
    [pbr::OriginalName("ACK_PROPERTY_OBJECT")] AckPropertyObject = 214,
    [pbr::OriginalName("ACK_PROPERTY_VECTOR2")] AckPropertyVector2 = 215,
    [pbr::OriginalName("ACK_PROPERTY_VECTOR3")] AckPropertyVector3 = 216,
    [pbr::OriginalName("ACK_PROPERTY_CLEAR")] AckPropertyClear = 217,
    [pbr::OriginalName("ACK_ADD_ROW")] AckAddRow = 220,
    [pbr::OriginalName("ACK_REMOVE_ROW")] AckRemoveRow = 221,
    [pbr::OriginalName("ACK_SWAP_ROW")] AckSwapRow = 222,
    [pbr::OriginalName("ACK_RECORD_INT")] AckRecordInt = 223,
    [pbr::OriginalName("ACK_RECORD_FLOAT")] AckRecordFloat = 224,
    /// <summary>
    ///EGMI_ACK_RECORD_DOUBLE				= 225;
    /// </summary>
    [pbr::OriginalName("ACK_RECORD_STRING")] AckRecordString = 226,
    [pbr::OriginalName("ACK_RECORD_OBJECT")] AckRecordObject = 227,
    [pbr::OriginalName("ACK_RECORD_VECTOR2")] AckRecordVector2 = 228,
    [pbr::OriginalName("ACK_RECORD_VECTOR3")] AckRecordVector3 = 229,
    [pbr::OriginalName("ACK_RECORD_CLEAR")] AckRecordClear = 250,
    [pbr::OriginalName("ACK_RECORD_SORT")] AckRecordSort = 251,
    [pbr::OriginalName("ACK_DATA_FINISHED")] AckDataFinished = 260,
    [pbr::OriginalName("REQ_MOVE")] ReqMove = 300,
    [pbr::OriginalName("ACK_MOVE")] AckMove = 301,
    [pbr::OriginalName("REQ_CHAT")] ReqChat = 350,
    [pbr::OriginalName("ACK_CHAT")] AckChat = 351,
    [pbr::OriginalName("REQ_SKILL_OBJECTX")] ReqSkillObjectx = 400,
    [pbr::OriginalName("ACK_SKILL_OBJECTX")] AckSkillObjectx = 401,
    [pbr::OriginalName("REQ_SKILL_POS")] ReqSkillPos = 402,
    [pbr::OriginalName("ACK_SKILL_POS")] AckSkillPos = 403,
    [pbr::OriginalName("REQ_MODEL_RAW")] ReqModelRaw = 500,
    [pbr::OriginalName("ACK_MODEL_RAW")] AckModelRaw = 501,
    [pbr::OriginalName("REQ_MODEL_INFO_LIST")] ReqModelInfoList = 502,
    [pbr::OriginalName("ACK_MODEL_INFO_LIST")] AckModelInfoList = 503,
    [pbr::OriginalName("REQ_MODEL_TARGET")] ReqModelTarget = 504,
    [pbr::OriginalName("ACK_MODEL_TARGET")] AckModelTarget = 505,
    [pbr::OriginalName("REQ_MODEL_SWITCH")] ReqModelSwitch = 506,
    [pbr::OriginalName("ACK_MODEL_SWITCH")] AckModelSwitch = 507,
    [pbr::OriginalName("REQ_MODEL_VIEW")] ReqModelView = 520,
    [pbr::OriginalName("ACK_MODEL_VIEW")] AckModelView = 521,
    [pbr::OriginalName("ACK_ONLINE_NOTIFY")] AckOnlineNotify = 600,
    [pbr::OriginalName("ACK_OFFLINE_NOTIFY")] AckOfflineNotify = 601,
  }

  public enum EItemType {
    /// <summary>
    ///the equipment which can add props
    /// </summary>
    [pbr::OriginalName("EIT_EQUIP")] EitEquip = 0,
    /// <summary>
    ///the gem ca be embed to the equipment
    /// </summary>
    [pbr::OriginalName("EIT_GEM")] EitGem = 1,
    /// <summary>
    ///expendable items for player, such as a medicine that cures
    /// </summary>
    [pbr::OriginalName("EIT_SUPPLY")] EitSupply = 2,
    /// <summary>
    ///special items that can call a hero or others, special items can do what you want to do
    /// </summary>
    [pbr::OriginalName("EIT_SCROLL")] EitScroll = 3,
  }

  public enum ESkillType {
    /// <summary>
    ///this kind of skill just can damage one object
    /// </summary>
    [pbr::OriginalName("BRIEF_SINGLE_SKILL")] BriefSingleSkill = 0,
    /// <summary>
    ///this kind of skill can damage multiple objects
    /// </summary>
    [pbr::OriginalName("BRIEF_GROUP_SKILL")] BriefGroupSkill = 1,
    /// <summary>
    ///this kind of bullet just can damage one object
    /// </summary>
    [pbr::OriginalName("BULLET_SINGLE_SKILL")] BulletSingleSkill = 2,
    /// <summary>
    ///this kind of bullet can damage multiple objects via rebound
    /// </summary>
    [pbr::OriginalName("BULLET_REBOUND_SKILL")] BulletReboundSkill = 3,
    /// <summary>
    ///this kind of bullet can damage multiple objects who around the target when the bullet touched the target object
    /// </summary>
    [pbr::OriginalName("BULLET_TARGET_BOMB_SKILL")] BulletTargetBombSkill = 4,
    /// <summary>
    ///this kind of bullet can damage multiple objects  who around the target when the bullet arrived the position
    /// </summary>
    [pbr::OriginalName("BULLET_POS_BOMB_SKILL")] BulletPosBombSkill = 5,
    [pbr::OriginalName("FUNC_SKILL")] FuncSkill = 6,
  }

  public enum ESceneType {
    /// <summary>
    ///public town, only has one group available for players is 1
    /// </summary>
    [pbr::OriginalName("NORMAL_SCENE")] NormalScene = 0,
    /// <summary>
    ///private room, only has one player per group and it will be destroyed if the player leaved from group.
    /// </summary>
    [pbr::OriginalName("SINGLE_CLONE_SCENE")] SingleCloneScene = 1,
    /// <summary>
    ///private room, only has more than one player per group and it will be destroyed if all players leaved from group.
    /// </summary>
    [pbr::OriginalName("MULTI_CLONE_SCENE")] MultiCloneScene = 2,
  }

  public enum ENPCType {
    /// <summary>
    /// </summary>
    [pbr::OriginalName("NORMAL_NPC")] NormalNpc = 0,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("HERO_NPC")] HeroNpc = 1,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("TURRET_NPC")] TurretNpc = 2,
    /// <summary>
    /// </summary>
    [pbr::OriginalName("FUNC_NPC")] FuncNpc = 3,
  }

  #endregion

}

#endregion Designer generated code
