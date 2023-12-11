
var GlobalFlag = false;
var CNT = 0;

//$(document).ready(function () {
//    $('[data-toggle="tooltip"]').tooltip();
//});
function SpinnerShow(Area, TITR) { if (typeof Area != 'object') Area = '#' + Area; if (TITR != null) { $(Area).html('<div class="w-100 text-center font-20 text-primary">' + TITR + '</div><div class="w-100"><img src="../images/loading.gif" class="w-max-100 mx-auto" /></div>'); } else { $(Area).html('<div class="w-100"><img src="../images/loading.gif" class="w-max-100 mx-auto" /></div>'); } }
function SpinnerShowBtn(Btn) {
    if (typeof Btn != 'object')
        Btn = '#' + Btn;

    $(Btn).html('<img src="../images/loading.gif" class="w-max-40" />');
}
function ChangLange(LNG) {
    var href = document.location.href;
    href = href.replace("/fa/", "/" + LNG + "/");
    href = href.replace("/en/", "/" + LNG + "/");
    href = href.replace("/ar/", "/" + LNG + "/");
    ShowMsg(LNG, href);
    location.href = href;
}
function copyToClipboard(txt, MSG) {
    var $temp = $("<textarea>");
    $("body").append($temp);

    $temp.val(txt).select();

    document.execCommand("copy");
    $temp.remove();

    if (MSG != '') {
        ShowMsg('kopyala', MSG);
    }
}
function isJsonString(str) {
    try {
        JSON.parse(str);
        return true;
    } catch (e) {
        ShowMsg('توجه', str);
        return false;
    }
}
function SelectRowColor(AREA, ROW) {
    SetHtml(AREA, EleHtml(AREA).replace('bg-info', ''));
    if (typeof ROW != 'object')
        ROW = '#' + ROW;
    $(ROW).addClass("bg-info");
}
function CheckErrorSelect(SEL) {
    if (!$('#' + SEL).html().includes('</option>'))
        ShowMsg('توجه', $('#' + SEL).html());
}
function SpinnerHide(Area) { $('#' + Area).text('') }
function SpinnerShowForm(TITR) { SpinnerHideForm(); $('#SpinnerMsg_TITR').text(TITR); $('#mySpinner').addClass('show'); $("#Spinner_Btn").click() }
function SpinnerHideForm() { $("#SpinnerHide_Btn").click(); }
function AreaShow(Area) { $('#' + Area).show(750) }
function AreaHide(Area) { $('#' + Area).hide(750) }
function AreaToggelSH(Area) { if ($('#' + Area).is(':visible')) { $('#' + Area).hide(750); } else { $('#' + Area).show(750); } }
function AreaToggel(Area) { if ($('#' + Area).is(':visible')) { $('#' + Area).slideUp(750); } else { $('#' + Area).slideDown(750); } }
function AreaUp(Area) { $('#' + Area).slideUp(750); }
function AreaDown(Area) { $('#' + Area).slideDown(750); }
function SetBackColor(Area) { $('#' + Area).addClass("badge-Learn"); }
function MsgShow(Area, MSG) { $('#' + Area).html('<div class="row"><div class="col font-17"><p class="badge-Learn w-max-350 mx-auto text-center spc-pre-line"><i class=" icofont-alarm font-22 text-warning mx-2"></i><span>' + MSG + '</span></p></div></div>'); }
function ShowMsg(TITR, MATN) { $("#ShowMsg_TITR").text(TITR); $("#ShowMsg_MATN").html(MATN); $("#ShowMsg_Btn").click(); }
function MsgForm(TITR, MATN) { $("#MsgForm_TITR").text(TITR); $("#MsgForm_MATN").html(MATN); $("#MsgFrom_Btn").click(); }
function SetHtml(Area, HTML) { $('#' + Area).html(HTML); }
function SelectWait(S, M) { $('#' + S).html("<option value='0'>" + M + "</option>"); }
function SelectOptionValue(S, A) { $('#' + A).val(S.value); }
function SelectOptionData(S, D) { return $('#' + S).find(':selected').attr(D); }
function SelectOptionText(S) { return S.options[S.selectedIndex].text; }
function MenuToggel() {
    if ($('#MenuArea').width() == 0) {
        $('#MenuArea').width(170);
        $('#MainArea').css("padding-right", "170px");
        $('#MenuBtn').removeClass('rotated0');
        $('#MenuBtn').addClass('rotated360Z');
        $('#MenuIcon_Right').removeClass('dis-none');
        $('#MenuIcon_Left').addClass('dis-none');
    }
    else {
        $('#MenuArea').width(0);
        $('#MainArea').css("padding-right", "0px");
        $('#MenuIcon_Left').removeClass('dis-none');
        $('#MenuIcon_Right').addClass('dis-none');
        $('#MenuBtn').removeClass('rotated360Z');
        $('#MenuBtn').addClass('rotated0');
    }
}


function GoToPos(P) { $('body,html').animate({ scrollTop: P }, 800); return false; }
function GoToPosArea(Area) { var x = $('#' + Area).position(); GoToPos(x.top - 50); }
function GoToPosTopArea(Area) { var x = $('#' + Area).position(); GoToPos(x.top - 100); }
//function Zoom(Pic) { $('#ZoomPic').html($('#' + Pic).html()); $("#Zoom_Btn").click(); }
function Zoom(Pic) { SetHtml('ZoomPic', EleHtml(Pic)); $("#Zoom_Btn").click(); }

function SetLocalValue(V) { // پرکردن مقدار جاری متغیر روی فرم
    $('#LocalValue').val(V);
}
function ChangIcon(S, I1, I2) {
    // تغییر یک آیکون
    S = '#' + S;
    Rotate(S, 'Z');
    if ($(S).hasClass(I1)) {
        $(S).removeClass(I1);
        $(S).addClass(I2);
    }
    else {
        $(S).removeClass(I2);
        $(S).addClass(I1);
    }
}
function ShowMenu() {
    if ($('#AreaMain').hasClass('MainLeft')) {
        $('#AreaMain').removeClass('MainLeft');
        $('#AreaMenu').removeClass('d-sm-block');
        $('#Icn_Menu_Left').removeClass('dis-none');
        $('#Icn_Menu_Right').addClass('dis-none');
        $('#MenuBtn').removeClass('rotated360Z');
        $('#MenuBtn').addClass('rotated0');
    }
    else {
        $('#AreaMain').addClass('MainLeft');
        $('#AreaMenu').addClass('d-sm-block');
        $('#Icn_Menu_Right').removeClass('dis-none');
        $('#Icn_Menu_Left').addClass('dis-none');
        $('#MenuBtn').removeClass('rotated0');
        $('#MenuBtn').addClass('rotated360Z');
    }
}
function Rotate(ELM, XYZ) {
    if (XYZ == 'Y')
        $(ELM).addClass('bg-info');

    if ($(ELM).hasClass('rotated360' + XYZ)) {
        $(ELM).removeClass('rotated360' + XYZ);
        $(ELM).addClass('rotated0');
    }
    else {
        $(ELM).removeClass('rotated0');
        $(ELM).addClass('rotated360' + XYZ);
    }
}

function MenuItemClick(ELM) {
    SpinnerShow('MainAreaActive', 'در حال لود فرم. چند لحظه صبر کنید ...');
    $(ELM).addClass('menu-Item');

}

$(document).ready(function () {
    $(window).scroll(function () {
        if ($(this).scrollTop() > 50) {
            $('#BtnGoToTop').fadeIn();
        } else {
            $('#BtnGoToTop').fadeOut();
        }
    });

    // scroll body to 0px on click
    $('#BtnGoToTop').click(function () {
        $('body,html').animate({
            scrollTop: 0
        }, 800);
        return false;
    });
    //$('#BtnGoToTop').tooltip('show');
});
function GoToTop() {
    $('#BtnGoToTop').click()
}

function GoToLeft(E, D) {
    document.getElementById('RepRes').scrollLeft += 20;//        $(E).scrollLeft(D);
}

function EnterKey(e, BTN) {
    //فشردن کلید اینتر برای کلیک روی یک دکمه دیگر
    var code = e.key;
    if (code === "Enter") {
        ClickBtnSimpl(BTN, '');
    }
}
function AddComma(INP) {
    $(INP).val(numberWithCommas($(INP).val()));
}
function numberWithCommas(x) {
    x = x.toString();
    x = numberClearCommas(x);
    x = x.replace(/^0+/, '');

    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}
function numberClearCommas(x) {
    x = x.toString();
    return x.replace(/,/g, "");
}
function EleValue(X) {
    if (typeof X != 'object')
        X = '#' + X;
    return $(X).val();
}
function EleText(X) {
    if (typeof X != 'object')
        X = '#' + X;
    return $(X).text();
}
function EleHtml(X) {
    if (typeof X != 'object')
        X = '#' + X;
    return $(X).html();
}

function SortListKala(Btn, FSort, Sort, Act, DAct, FTp = '', Tp = '') {
    //تغییر رنگ دکمه های سورت کالا و پرکردن فیلدها مربوط برای اصلاح گزارش کالا
    $('#' + FSort).val(Sort);

    if (FTp != "") {
        if (typeof FTp != 'object')
            FTp = '#' + FTp;
        $(FTp).val(Tp);
    }
    $('#' + Btn).click();

    $('#' + DAct).removeClass("btn_Selected");
    if (Act != "") {
        if (typeof Act != 'object')
            Act = '#' + Act;
        $(Act).addClass("btn_Selected");
    }
}
function RowSelect(ROW) {
    if (GlobalFlag) {
        $('#' + ROW).addClass("Row_Select_F");
        GlobalFlag = false;
    } else {
        $('#' + ROW).addClass("Row_Select_Z");
        GlobalFlag = true;
    }

}
function Btn_Select(Act, BTNArea, KND) {
    //در ناحیه مشخص شده عنصرهای مختلف را پیدا میکند و رنگشون رااز حالت انتخاب در میاره و اونی که فعال است را رنگش را به حالات انتخاب میبرد
    $('#' + BTNArea).find(KND).removeClass("btn_Selected");
    if (typeof Act != 'object')
        Act = '#' + Act;
    $(Act).addClass("btn_Selected");
}
function Btn_SelectFlat(Act, BTNArea, KND) {
    //در ناحیه مشخص شده عنصرهای مختلف را پیدا میکند و رنگشون رااز حالت انتخاب در میاره و اونی که فعال است را رنگش را به حالات انتخاب میبرد
    $('#' + BTNArea).find(KND).removeClass("btn_SelectedFlat");
    if (typeof Act != 'object')
        Act = '#' + Act;
    $(Act).addClass("btn_SelectedFlat");
}
function Area_Select(Act, Area, KND) {
    //در ناحیه مشخص شده عنصرهای مختلف را پیدا میکند و پنهانشون میکنه و فقط یکی را نمایش میده
    $('#' + Area).find(KND).slideUp(1000);
    if (typeof Act != 'object')
        Act = '#' + Act;
    $(Act).slideDown(1000);
}
// کنترل اینکه بعد از گزارش چاپ میگیرد یا نه
function ControlChap(BTN) {
    if (EleValue(BTN) == "CHAP") {
        ChapShow();
    }
    if (EleValue(BTN) == "EXL") {
        ExcelShow();
    }
    if (EleValue(BTN) == "PDF") {
        PdfShow();
    }
}
function ChapShow() {
    // تابع نمایش PDF برای چاپ گرفتن 
    //  printJS('../Upload/' + EleValue('PdfFileName') + "?" + $.now())
    PdfShow();
}
function ExcelShow() {
    //    $("#ExcelShow").attr("href", "../Upload/BenIceReport.xlsx?" + $.now());
    $("#ExcelShow").attr("href", "../Upload/" + EleValue('ExcelFileName') + "?" + $.now());
    $("#ExcelShow").click();
    document.getElementById("ExcelShow").click();
}
function PdfShow() {
    $("#PdfShow").attr("href", "../Upload/" + EleValue('PdfFileName') + "?" + $.now());
    //    $("#PdfShow").click();
    document.getElementById("PdfShow").click();
}
function expand(obj) {
    obj.size = 5;
}
function unexpand(obj) {
    obj.size = 1;
}
function HelpShow() {
    if ($("#HelpArea").text() == "")
        $("#HelpBtn").click();

    GoToPosArea("HelpArea");
}
function SetTextMain(A = '', T) {
    if (A == '')
        return;
    if (typeof A != 'object')
        A = '#' + A;
    $(A).text(T);
}
function SetText(A1, T1, A2, T2, A3, T3, A4, T4, A5, T5, A6, T6, A7, T7, A8, T8, A9, T9, A10, T10) {
    //نوشتن متن برای 10 ناحیه
    SetTextMain(A1, T1);
    SetTextMain(A2, T2);
    SetTextMain(A3, T3);
    SetTextMain(A4, T4);
    SetTextMain(A5, T5);
    SetTextMain(A6, T6);
    SetTextMain(A7, T7);
    SetTextMain(A8, T8);
    SetTextMain(A9, T9);
    SetTextMain(A10, T10);
}
function SetValueMain(E = '', V) {
    if (E == '')
        return;
    if (typeof E != 'object')
        E = '#' + E;
    $(E).val(EleValue(V));
}
function SetValue(E1, V1, E2, V2, E3, V3, E4, V4, E5, V5, E6, V6, E7, V7, E8, V8, E9, V9, E10, V10) {
    //جایگزینی مقدار برای 10 عنصر
    SetValueMain(E1, V1);
    SetValueMain(E2, V2);
    SetValueMain(E3, V3);
    SetValueMain(E4, V4);
    SetValueMain(E5, V5);
    SetValueMain(E6, V6);
    SetValueMain(E7, V7);
    SetValueMain(E8, V8);
    SetValueMain(E9, V9);
    SetValueMain(E10, V10);
}
function SetValueSimplMain(F = '', V = '') {
    if (F == '')
        return;
    if (typeof F != 'object')
        F = '#' + F;
    $(F).val(V);
}
function SetValueSimpl(F1, V1, F2, V2, F3, V3, F4, V4, F5, V5, F6, V6, F7, V7, F8, V8, F9, V9, F10, V10) {
    // مقدار دهی ساده برای 10 فیلد
    SetValueSimplMain(F1, V1);
    SetValueSimplMain(F2, V2);
    SetValueSimplMain(F3, V3);
    SetValueSimplMain(F4, V4);
    SetValueSimplMain(F5, V5);
    SetValueSimplMain(F6, V6);
    SetValueSimplMain(F7, V7);
    SetValueSimplMain(F8, V8);
    SetValueSimplMain(F9, V9);
    SetValueSimplMain(F10, V10);
}
function ClickBtnSimpl(BTN, VALU, F1, V1, F2, V2, F3, V3, F4, V4, F5, V5, F6, V6, F7, V7, F8, V8, F9, V9, F10, V10) {
    // مقدار دکمه و سایر فیلدها را به صورت ساده مقدار گزاری کند و کلیک کند
    SetValueSimpl(F1, V1, F2, V2, F3, V3, F4, V4, F5, V5, F6, V6, F7, V7, F8, V8, F9, V9, F10, V10);

    if (typeof BTN != 'object')
        BTN = '#' + BTN;
    if (VALU != '')
        $(BTN).val(VALU);

    $(BTN).click();
}
function ClickBtnValu(BTN, Element, F1, EL1, F2, EL2, F3, EL3, F4, EL4, F5, EL5, F6, EL6, F7, EL7, F8, EL8, F9, EL9, F10, EL10) {
    // مقدار دکمه و سایر فیلدها را از مقدار سایر عنصرها مقدارگزاری کند و کلیک کند
    SetValue(F1, EL1, F2, EL2, F3, EL3, F4, EL4, F5, EL5, F6, EL6, F7, EL7, F8, EL8, F9, EL9, F10, EL10);

    if (typeof BTN != 'object')
        BTN = '#' + BTN;
    if (Element != '')
        $(BTN).val(EleValue(Element));

    $(BTN).click();
}
function ClickBtnSimplValu(BTN, VALU, F1 = '', EL1, F2 = '', EL2, F3 = '', EL3, F4 = '', EL4, F5 = '', EL5, F6 = '', EL6, F7 = '', EL7, F8 = '', EL8, F9 = '', EL9, F10 = '', EL10) {
    // مقدار یک دکمه را به صورت ساده بنویسید
    // مقادیر 10 عنصرهای دیگر را از عنصرهای دیگر بگیرد 
    SetValue(F1, EL1, F2, EL2, F3, EL3, F4, EL4, F5, EL5, F6, EL6, F7, EL7, F8, EL8, F9, EL9, F10, EL10);

    if (typeof BTN != 'object')
        BTN = '#' + BTN;
    if (VALU != '')
        $(BTN).val(VALU);

    $(BTN).click();

}
function ClickBtnValuSimpl(BTN, Element, F1, V1, F2, V2, F3, V3, F4, V4, F5, V5, F6, V6, F7, V7, F8, V8, F9, V9, F10, V10) {
    // مقدار دکمه و سایر فیلدها را به صورت ساده مقدار گزاری کند و کلیک کند
    SetValueSimpl(F1, V1, F2, V2, F3, V3, F4, V4, F5, V5, F6, V6, F7, V7, F8, V8, F9, V9, F10, V10);

    if (typeof BTN != 'object')
        BTN = '#' + BTN;
    if (Element != '')
        $(BTN).val(EleValue(Element));

    $(BTN).click();
}

// اجرای گزارش گرفتن سریع
function RunFastReport(DATE, BTN, FORM, LD) {
    // ابتدا تاریخ ست میشود و سپس گزارش گرفته میشود
    ClickBtnSimpl('LimitDateBtn', BTN
        , 'LimitDateKnd', DATE
        , 'LimitDateForm', FORM
        , BTN, '0');
    if (LD != '') {
        SetValueSimpl(LD, DATE);
    }
}
//-- توابع انتخاب تاریخ
function LimitDate(Lim, FORM) {
    // فقط تاریخ ست میشود و گزارش گرفته نمیشود
    ClickBtnSimpl('LimitDateBtn', ''
        , 'LimitDateKnd', EleValue(Lim)
        , 'LimitDateForm', FORM);
    SpinnerShow('waitLimitDate' + FORM);
}
// بعد از گرفتن تاریخ دکمه گزارش کلیک شود
LimitDateCompelete = function (result) {
    // تاریخ
    if (isJsonString(result.responseText)) {
        var RD = JSON.parse(result.responseText);
        var FORM = EleValue('LimitDateForm');
        // دکمه گزارش گیری
        var BTN = EleValue('LimitDateBtn');
        // ست کردن تاریخ
        SetValueSimpl('FromDay' + FORM, RD.fromDay
            , 'FromMonth' + FORM, RD.fromMonth
            , 'FromYear' + FORM, RD.fromYear
            , 'ToDay' + FORM, RD.toDay
            , 'ToMonth' + FORM, RD.toMonth
            , 'ToYear' + FORM, RD.toYear);
        SpinnerHide('waitLimitDate' + FORM);
        // اجرای گزارش
        if (BTN != '') {
            $('#' + BTN).click();
        }
    }
}

function GetPhoto(FILE, NAME, PHOTO) {
    var file = FILE.files[0];
    var filename = file.name;
    if (NAME != "") {
        SetText(NAME, filename);
    }
    if (FILE.files && FILE.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#' + PHOTO).attr('src', e.target.result);
        };
        reader.readAsDataURL(FILE.files[0]);
    }
}

function SelectGrp(Active, BTN) {
    // تغییر رنگ دگمه با انتخاب
    if ($(Active).hasClass('btn_SelectedFlat')) {
        $(Active).removeClass('btn_SelectedFlat');
    }
    else {
        $(Active).addClass('btn_SelectedFlat');
    }
    // ساخت مقدار دسته های انتخاب شده

    var GrpKnd = '';
    if ($('#' + BTN + 'A').hasClass('btn_SelectedFlat')) { GrpKnd += 'A' }
    if ($('#' + BTN + 'B').hasClass('btn_SelectedFlat')) { GrpKnd += 'B' }
    if ($('#' + BTN + 'C').hasClass('btn_SelectedFlat')) { GrpKnd += 'C' }
    // کلیک برروی جستجوی لیست گروهها
    ClickBtnSimpl(BTN + 'Btn', GrpKnd);
}
function AddCommaDP(A, B) {
    NA = EleValue(A);
    if (NA != "" & NA != "0") {
        AddComma(A);
        SetValueSimplMain(B, '0');
    }
}


NewProdCom = function (RES) {
    if (isJsonString(RES.responseText)) {
        var RD = JSON.parse(RES.responseText);
        if (RD.id == "OK") {
            ClickBtnSimpl('SearchProdBtn', '');
        }
        ShowMsg('ذخیره محصول جدید ', RD.value);
    }
}
SaveProdInfoComp = function (RES) {
    ShowMsg('ذخیره محصول جدید ', RES.responseText);
}
UpdatePropComp = function (RES) {
    SpinnerHideForm();
    ShowMsg('ذخیره ویژگی ', RES.responseText);
}

function FindProp(ID) {
    AreaToggel('Kala_' + ID);
    if (EleText('Prop_' + ID) == '') {
        SpinnerShow('Prop_' + ID, 'بازنشانی ویژگی ها');
        ClickBtnSimpl('FindPropBtn', ID);
    }
}
FindPropComp = function (RES) {
    SetHtml('Prop_' + EleValue('FindPropBtn'), RES.responseText);
}


NewProdUpdate = function (RES) {
    if (isJsonString(RES.responseText)) {
        var RD = JSON.parse(RES.responseText);
        if (RD.value == "OK") {
            ClickBtnSimpl('NEWKalaBtn', '');
        }
        ShowMsg('ذخیره محصول جدید ', RD.tp);
    }
}
