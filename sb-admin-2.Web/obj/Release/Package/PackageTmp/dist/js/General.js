/**
 * @param {string} T  SucsessDelete,UnSucsessDelete,SucsessInsert,UnSucsessInsert,SucsessEdit,UnSucsessEdit
 */

function ShowAlert(T) {
    switch (T) {
        case 'SucsessDelete':
            swal({ title: "حذف با موفقیت انجام شد.", icon: "success", closeOnEsc: true, timer: 5000, }); break;
        case 'UnSucsessDelete':
            swal({ title: "خطا در حذف اطلاعات!", icon: "error", closeOnEsc: true, timer: 5000, }); break;
        case 'SucsessInsert':
            swal({ title: "عملیات درج با موفقیت انجام شد.", icon: "success", closeOnEsc: true, timer: 5000, }); break;
        case 'UnSucsessInsert':
            swal({ title: "خطا در درج اطلاعات!", icon: "error", closeOnEsc: true, timer: 5000, }); break;
        case 'RepeatedInsert':
            swal({ title: "اطلاعات وارد شده تکراری است", icon: "error", closeOnEsc: true, timer: 5000, }); break;
        case 'SucsessEdit':
            swal({ title: "عملیات ویرایش با موفقیت انجام شد.", icon: "success", closeOnEsc: true, timer: 5000, }); break;
        case 'UnSucsessEdit':
            swal({ title: "خطا در ویرایش اطلاعات!", icon: "error", closeOnEsc: true, timer: 5000, }); break;
        case 'SucsessRegWO':
            swal({ title: "ثبت دستور کار با موفقیت صورت پذیرفت.", icon: "success", closeOnEsc: true, timer: 5000, }); break;
        case 'UnSucsessRegWO':
            swal({ title: "خطا در ثبت دستور کار!", icon: "error", closeOnEsc: true, timer: 5000, }); break;  
        case 'UnSucsessLogin':
            swal({ title: "نام کاربری و یا گذرواژه اشتباه است!", icon: "error", closeOnEsc: true, timer: 5000, }); break;

    }
}
/**
 * @param {string} DeleteLink  Url for delete operation for example ...X/delete/5.
 */
function deleteDep(DeleteLink) {
    swal({
        title: "آیا مطمئنید؟",
        text: "با حذف این رکورد تمام اطلاعات آن حذف خواهد شد",
        type: "warning",
        icon: "warning",
        buttons: {
            true: "بله",
            false: "خیر"
        },
        dangerMode: true,
        closeOnEsc: true,
    }).then((Value) => {

        if (Value == 'true')
            window.location = DeleteLink;
    });
   
}

function alertandgo(link,msg,title) {
    swal({
        title: title,
        text: msg,
        type: "warning",
        icon: "warning",
        buttons: {
            true: "بله",
            false: "خیر"
        },
        dangerMode: true,
        closeOnEsc: true,
    }).then((Value) => {

        if (Value == 'true')
            window.location = link;
    });

}
/**
 * @param {string} Page      New:CreateView,Index:IndexView
 * @param {string} PageLink  Url for redirection.
 */
function Exit(Page, PageLink) {
    swal({
        title: "آیا مطمئنید؟",
        text: "با خروج از صفحه تغییرات ذخیره نمی شوند",
        type: "warning",
        icon: "warning",
        buttons: {
            true: "بله",
            false: "خیر"
        },
        dangerMode: true,
        closeOnEsc: true,
    }).then((Value) => {

        if (Value == 'true')
            if (Page == 'Index')
                window.location = PageLink;
            else if (Page == 'New')
                window.location = PageLink;
    });
}

function idleTimer() {
    var t;
    //window.onload = resetTimer;
    window.onmousemove = resetTimer; // catches mouse movements
    window.onmousedown = resetTimer; // catches mouse movements
    window.onclick = resetTimer;     // catches mouse clicks
    window.onscroll = resetTimer;    // catches scrolling
    window.onkeypress = resetTimer;  //catches keyboard actions

    function logout() {
        swal({
          
            text: "به علت غیر فعال بودن لطفا دوباره وارد شوید",
            type: "warning",
            icon: "warning",
            buttons: {
                true: "بله",
              
            },
            dangerMode: true,
            closeOnEsc: true,
        }).then((Value) => {

            window.location.href = '/Login/index';
        });
        //Adapt to actual logout script
    }

   function reload() {
          window.location = self.location.href;  //Reloads the current page
   }

   function resetTimer() {
        clearTimeout(t);
        t = setTimeout(logout, 2000);  // time is in milliseconds (1000 is 1 second)
      
    }
}
//idleTimer();
function CheckDateformat(textbox) {
    ["blur"].forEach(function (event) {
        textbox.addEventListener(event, function () {
            if (textbox.value == "")
                return;
            if (/^[\u06F1-\u06F9]{4}[\/\-](\u06F0?[\u06F1-\u06F9]|\u06F1[\u06F0\u06F1\u06F2])[\/\-](\u06F0?[\u06F0-\u06F9]|[\u06F1\u06F2][\u06F0-\u06F9]|\u06F3[\u06F0\u06F1])$/.test(textbox.value) != true)
                swal({
                    title: "خطا؟",
                    text: "تاریخ وارد شده صحیح نمی باشد",
                    type: "error",
                    icon: "error",
                    buttons: {
                        true: "اصلاح",
                    },
                    dangerMode: true,
                    closeOnEsc: true,
                }).then((Value) => {
                    $(this).focus();

                });
        });
    });
}
function CompaireDate(StartDate, EndDate) {
   
    ["blur"].forEach(function (event) {
        EndDate.addEventListener(event, function () {
            alert(StartDate.value > EndDate.value);
            if (EndDate.value == "")
                return;
            if (StartDate.value > EndDate.value) {
                EndDate.value = "";
                swal({
                    title: "خطا؟",
                    text: "تاریخ پایان باید بعد از تاریخ شروع باشد",
                    type: "error",
                    icon: "error",
                    buttons: {
                        true: "اصلاح",
                    },
                    dangerMode: true,
                    closeOnEsc: true,
                }).then((Value) => {
                    $(this).focus();

                });
            }
        });
    });
}
function CheckTimeformat(textbox) {
    ["blur"].forEach(function (event) {
        textbox.addEventListener(event, function () {
            if (textbox.value == "")
                return;
            if (/^(([\u06F0-\u06F9]|[\u06F0\u06F1][\u06F0-\u06F9]|\u06F2[\u06F0-\u06F3]):([\u06F0-\u06F5][\u06F0-\u06F9]|[\u06F0-\u06F9]))$/.test(textbox.value) != true)
                swal({
                    title: "خطا؟",
                    text: "زمان وارد شده صحیح نمی باشد",
                    type: "error",
                    icon: "error",
                    buttons: {
                        true: "اصلاح",
                    },
                    dangerMode: true,
                    closeOnEsc: true,
                }).then((Value) => {
                    $(this).focus();

                });
        });
    });
}
function CheckBigTimeformat(textbox) {
    ["blur"].forEach(function (event) {
        textbox.addEventListener(event, function () {
            if (textbox.value == "")
                return;
            if (/^(([\u06F0-\u06F9]|[\u06F0-\u06F9][\u06F0-\u06F9])|(([\u06F0-\u06F9]|[\u06F0-\u06F9][\u06F0-\u06F9]):([\u06F0-\u06F5][\u06F0-\u06F9]|[\u06F0-\u06F9])))$/.test(textbox.value) != true)
                swal({
                    title: "خطا؟",
                    text: "زمان وارد شده صحیح نمی باشد",
                    type: "error",
                    icon: "error",
                    buttons: {
                        true: "اصلاح",
                    },
                    dangerMode: true,
                    closeOnEsc: true,
                }).then((Value) => {
                    $(this).focus();

                });
        });
    });
}
function CheckNumberBetween(textbox,start,end) {
    ["blur"].forEach(function (event) {
        textbox.addEventListener(event, function () {
            
            if (textbox.value == "")
                return;
            if (parseInt(textbox.value) > end || parseInt(textbox.value) < start) {
               
                swal({
                    title: "خطا؟",
                    text: "روز وارد شده صحیح نمی باشد",
                    type: "error",
                    icon: "error",
                    buttons: {
                        true: "اصلاح",
                    },
                    dangerMode: true,
                    closeOnEsc: true,
                }).then((Value) => {
                    $(this).focus();
                });
            }
        });
    });
}
function setInputFilter(textbox, type) {
    ["input", "keydown", "keyup", "mousedown", "mouseup", "select", "contextmenu", "drop"].forEach(function (event) {
        textbox.addEventListener(event, function () {
            if (inputFilter(this.value, type)) {
                this.oldValue = this.value;
                this.oldSelectionStart = this.selectionStart;
                this.oldSelectionEnd = this.selectionEnd;
            } else if (this.hasOwnProperty("oldValue")) {
                this.value = this.oldValue;
                this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
            }
        });
    });
}
function inputFilter(value, type)
{
    if (type =='int_float')
        return /^-?\d*[.,]?\d*$/.test(value);
    if (type == 'Fa_int')
        return /^[\u06F1-\u06F9]*$/.test(value);
    return true;
};

String.prototype.toFaDigit = function () {
    
   
    return this.toString().replace(/\d+/g, function (digit) {
        var ret = '';
        for (var i = 0, len = digit.length; i < len; i++) {
            ret += String.fromCharCode(digit.charCodeAt(i) + 1728);
        }

        return ret;
    });
};
String.prototype.toEnDigit = function () {
    return this.toString().replace(/\d+/g, function (digit) {
        var ret = '';
        for (var i = 0, len = digit.length; i < len; i++) {
            ret += String.fromCharCode(digit.charCodeAt(i) - 1728);
        }

        return ret;
    });
};

//##################### En To Farsi $ Fa to En##################
