using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SafeControl.Enum
{
    /// <summary>
    /// Enum: iPersonHistoryLogType
    /// CreateBy: truongnm 25.03.2022
    /// </summary>
    [TypeConverter(typeof(EnumConvert.LocalizedEnumConverter))]
    public enum iPersonHistoryLogType
    {
        None = 0,
        Null = 1,
        Email = 101,
        Sms = 201,
    }
    /// <summary>
    /// Enum: if8SendAPI_Email_FileAttachDialog
    /// CreateBy: truongnm 25.03.2022
    /// </summary>
    [TypeConverter(typeof(EnumConvert.LocalizedEnumConverter))]
    public enum if8SendAPI_Email_FileAttachDialog
    {
        None = 1,
        Email = 101,
        Email_Active_HopDong = 102,
        Sms = 201,
        Sms_Active_HopDong = 202,
        Sms_DenHan = 203,
    }
    /// <summary>
    /// Enum: iSelectEmailOrSms
    /// CreateBy: truongnm 09.03.2022
    /// </summary>
    [TypeConverter(typeof(EnumConvert.LocalizedEnumConverter))]
    public enum iSelectEmailOrSms
    {
        SendEmail = 101,
        //
        SendSms = 201,
        SendSms_1 = 202,
        SendSmsByTemplate = 203,
        SendSmsByBatch = 204,
        SendSmsToFirebase = 205,
    }
    // -------------------------------------------------------
    /// <summary>
    /// Enum control iOption_f8SendAPI   
    /// CreateBy: truongnm 10-03-2022
    /// </summary>
    [TypeConverter(typeof(EnumConvert.LocalizedEnumConverter))]
    public enum iOption_f8SendAPI
    {
        None = 0,
        LoadData = 1,
        Email = 100,
        SendEmail = 101,
        Sms = 200,
        SendSms = 201,
        SendSms_1 = 202,
        SendSmsByTemplate = 203,
        SendSmsByBatch = 204,
        SendSmsToFirebase = 205,
        RunCUrl = 999,
    }
    /// <summary>
    /// Các loại bản đồ: iMapType
    /// CreateBy: truongnm 19-08-2020
    /// </summary>
    [TypeConverter(typeof(EnumConvert.LocalizedEnumConverter))]
    public enum iMapType
    {
        GoogleMap = 101,
        GoogleMapMaker = 102,
        GoogleSatellite = 103,
        //
        BingMapSatellite = 201,
    }
    /// <summary>
    /// Các loại kí tự đặc biệt quan tâm: iCharSpecial
    /// CreateBy: truongnm 01-07-2019
    /// </summary>
    [TypeConverter(typeof(EnumConvert.LocalizedEnumConverter))]
    public enum iCharSpecial
    {
        None = 0,
        Space = 1,
    }
    
    /// <summary>
    /// Các loại kí tự đánh dấu: iDanhDau
    /// CreateBy: truongnm 29-07-2019
    /// </summary>
    [TypeConverter(typeof(EnumConvert.LocalizedEnumConverter))]
    public enum iDanhDau
    {
        Number = 0,
        CharSpecial1 = 1,
        Dictionary = 99,
    }
    /// <summary>
    /// Các iDaySelect
    /// CreateBy: truongnm 17-03-2022
    /// </summary>
    [TypeConverter(typeof(EnumConvert.LocalizedEnumConverter))]
    public enum iDaySelect
    {
        NN = 0,
        N1 = 1,
        N2 = 2,
        N3 = 3,
        N5 = 5,
        N7 = 7,
        N14 = 14,
        N30 = 30,
        N45 = 45,
        N60 = 60,
        NHY = 180,
        N1Y = 365,
        N1HY = 545,
        N2Y = 730,
        N3Y = 1095,
        N5Y = 1825,
        N10Y = 3650,
        N20Y = 7300,
        N30Y = 10950,
        N50Y = 18250,
    }
    /// <summary>
    /// Phân trang
    /// CreateBy: truongnm 25-05-2017
    /// </summary>
    [TypeConverter(typeof(EnumConvert.LocalizedEnumConverter))]
    public enum PageSize
    {
        NOLIMIT = 0,
        NAM = 5,
        MUOI = 10,
        MUOILAM = 15,
        HAIMUOI = 20,
        NAMMUOI = 50,
        MOTTRAM = 100,
        NAMTRAM = 500,
        MOTNGHIN = 1000,
        HAINGHIN = 2000,
        NAMNGHIN = 5000,
        MOTTRAMNGHIN = 100000,
        HAITRAMNGHIN = 200000,
        NAMTRAMNGHIN = 500000,
        MOTTRIEU = 1000000,
        MOTTRIEUNAMTRAMNGHIN = 1500000,
        HAITRIEU = 2000000,
    }
    // -------------------------------------------------------
    /// <summary>
    /// Enum Ngày
    /// CreateBy: truongnm 25-05-2017
    /// </summary>
    [TypeConverter(typeof(EnumConvert.LocalizedEnumConverter))]
    public enum Ngay
    {
        Ngay1 = 1,
        Ngay2 = 2,
        Ngay3 = 3,
        Ngay4 = 4,
        Ngay5 = 5,
        Ngay6 = 6,
        Ngay7 = 7,
        Ngay8 = 8,
        Ngay9 = 9,
        Ngay10 = 10,
        Ngay11 = 11,
        Ngay12 = 12,
        Ngay13 = 13,
        Ngay14 = 14,
        Ngay15 = 15,
        Ngay16 = 16,
        Ngay17 = 17,
        Ngay18 = 18,
        Ngay19 = 19,
        Ngay20 = 20,
        Ngay21 = 21,
        Ngay22 = 22,
        Ngay23 = 23,
        Ngay24 = 24,
        Ngay25 = 25,
        Ngay26 = 26,
        Ngay27 = 27,
        Ngay28 = 28,
        Ngay29 = 29,
        Ngay30 = 30,
        Ngay31 = 31
    }
    // -------------------------------------------------------
    /// <summary>
    /// Enum Tháng
    /// CreateBy: truongnm 25-05-2017
    /// </summary>
    [TypeConverter(typeof(EnumConvert.LocalizedEnumConverter))]
    public enum Thang
    {
        Thang1 = 1,
        Thang2 = 2,
        Thang3 = 3,
        Thang4 = 4,
        Thang5 = 5,
        Thang6 = 6,
        Thang7 = 7,
        Thang8 = 8,
        Thang9 = 9,
        Thang10 = 10,
        Thang11 = 11,
        Thang12 = 12
    }
    // -------------------------------------------------------
    /// <summary>
    /// Enum Năm
    /// CreateBy: truongnm 25-05-2017
    /// </summary>
    [TypeConverter(typeof(EnumConvert.LocalizedEnumConverter))]
    public enum Nam
    {
        Nam2010 = 2010,
        Nam2011 = 2011,
        Nam2012 = 2012,
        Nam2013 = 2013,
        Nam2014 = 2014,
        Nam2015 = 2015,
        Nam2016 = 2016,
        Nam2017 = 2017,
        Nam2018 = 2018,
        Nam2019 = 2019,
        Nam2020 = 2020,
        Nam2021 = 2021,
        Nam2022 = 2022,
        Nam2023 = 2023,
        Nam2024 = 2024,
        Nam2025 = 2025,
        Nam2026 = 2026,
        Nam2027 = 2027,
        Nam2028 = 2028,
        Nam2029 = 2029,
        Nam2030 = 2030
    }
    // -------------------------------------------------------
    /// <summary>
    /// Enum control OptionSelect // 0: Insert, 1: Update, 2: CopyPaste
    /// CreateBy: truongnm 10-04-2018
    /// </summary>
    [TypeConverter(typeof(EnumConvert.LocalizedEnumConverter))]
    public enum iOptionSelect
    {
        Insert = 0,
        Update = 1,
        CopyPaste = 2,
        Delete = 3,
    }
    // -------------------------------------------------------
    /// <summary>
    /// Enum control iOption_fBaseList
    /// CreateBy: truongnm 10-04-2018
    /// </summary>
    [TypeConverter(typeof(EnumConvert.LocalizedEnumConverter))]
    public enum iOption_fBaseList
    {
        Insert = 0,
        Update = 1,
        CopyPaste = 2,
        Search = 3,
        //
        MoveFirstItem = 4,
        MoveLastItem = 5,
        MoveNextItem = 6,
        MovePreviousItem = 7,
        MovePage = 8,
    }
   
    
    
    // -------------------------------------------------------
    /// <summary>
    /// Enum control iLanguage 
    /// CreateBy: truongnm 07-11-2019
    /// </summary>
    [TypeConverter(typeof(EnumConvert.LocalizedEnumConverter))]
    public enum iLanguage
    {
        EN = 1,
        FR = 2,
        RU = 3,
        TH = 4,
        VI = 5,
    }
   
    // -------------------------------------------------------
    /// <summary>
    /// Enum control iOption_fTableKey_Base
    /// CreateBy: truongnm 08-04-2019
    /// </summary>
    [TypeConverter(typeof(EnumConvert.LocalizedEnumConverter))]
    public enum iOption_fTableKey_Base
    {
        Open = 0,
        Save = 1,
        Decode = 2,
        Encode = 3,
        New = 4,
        Add = 5,
        Edit = 6,
    }
    
    // -------------------------------------------------------
    /// <summary>
    /// Enum control iSort
    /// CreateBy: truongnm 02-05-2019
    /// </summary>
    [TypeConverter(typeof(EnumConvert.LocalizedEnumConverter))]
    public enum iSort
    {
        NoSort = 0,
        Ascending = 1,
        Descending = 2,
    }
    
    // -------------------------------------------------------
    /// <summary>
    /// Enum phân loại tài liệu
    /// CreateBy: truongnm 25-05-2017
    /// </summary>
    [TypeConverter(typeof(EnumConvert.LocalizedEnumConverter))]
    public enum iIDDocumentType
    {
        GIAY = 0,
        TAILIEUSO = 1,
        CAHAILOAI = 2,
    }
    
    // -------------------------------------------------------
    /// <summary>
    /// Enum Ghi nhật ký DocumentLog
    /// CreateBy: truongnm 25-05-2017
    /// </summary>
    [TypeConverter(typeof(EnumConvert.LocalizedEnumConverter))]
    public enum iDocumentLog
    {
        TAOMOI = 0,
        SUA = 1,
        NHANBAN = 2,
    }
    // -------------------------------------------------------
    /// <summary>
    /// Enum Chuyển hướng
    /// CreateBy: truongnm 25-05-2017
    /// </summary>
    [TypeConverter(typeof(EnumConvert.LocalizedEnumConverter))]
    public enum iChuyenHuong
    {
        ADMIN = 100,                // Chuyển hướng sang giao diện ADMIN
        NGUOIDUNG = 101,            // Chưởng hướng sang giao diện UI người dùng
    }
    // -------------------------------------------------------
    /// <summary>
    /// Enum Phân loại tài liệu tham khảo: iPhanLoaiTaiLieuThamKhao
    /// CreateBy: truongnm 06-07-2017
    /// EditBy: truongnm 13-02-2018
    /// </summary>
    [TypeConverter(typeof(EnumConvert.LocalizedEnumConverter))]
    public enum iPhanLoaiTaiLieuThamKhao
    {
        // -------------------------------------------------------
        // Enum: Sách: 201, Mô tả kỹ thuật của các trang bị: 202; Chào hàng từ các hãng: 203; Khác: 204;
        SACH = 201,
        MOTAKYTHUATCUACACTRANGBI = 202,
        CHAOHANGTUCACHANG = 203,
        KHAC = 204,
    }
    
    // -------------------------------------------------------
    /// <summary>
    /// Enum Phân loại đề tài khoa học: iPhanLoaiDeTaiKhoaHoc
    /// CreateBy: truongnm 07-02-2018
    /// </summary>
    [TypeConverter(typeof(EnumConvert.LocalizedEnumConverter))]
    public enum iPhanLoaiDeTaiKhoaHoc
    {
        // -------------------------------------------------------
        // Enum: Đề tài: 201, Kế hoạch: 202; Chuyên đề: 203; Khác: 204;
        DETAI = 201,
        KEHOACH = 202,
        CHUYENDE = 203,
        KHAC = 204,
    }
    
}
