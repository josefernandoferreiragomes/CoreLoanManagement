////////////////////////////////
//Observer library declaration//
////////////////////////////////

////////////////////////////////
//Observer prototype declaration//
////////////////////////////////
function ObserverObj(elemId) {
    console.log("observer created " + elemId);
    this.elementId = elemId;
    this.notify = (function (elemVal) {
        console.log("observer notify")
        $("#" + this.elementId).val("1 " + elemVal);
    }).bind(this);
}

////////////////////////////////
//Observable prototype declaration//
////////////////////////////////
function ObservableObj(elemId) {    
    console.log("observable created " + elemId);
    this.elementId = elemId;
    this.observerList = new Array();
    this.notifyObservers = (function () {
        
        for (var i = 0; i < this.observerList.length; i++) {
            this.observerList[i].notify($("#" + this.elementId).val());
        }
        console.log("notify observers");
    }).bind(this);
    this.addObserver = (function (observerObj) {
        this.observerList.push(observerObj);
        console.log("observer added: " + observerObj.elementId);
    }).bind(this);
    this.AttatchFocusOut = (function () {
        $("#" + this.elementId).focusout(this.notifyObservers);
    }).bind(this);
}

////////////////////////////////
//Observer class declaration//
////////////////////////////////
class ObserverClass {

    constructor(elemId) {
        this.elementId = elemId;
    }
    notify = (function (elemVal) {
        console.log("super class observer notify")
                
    }).bind(this)
}

////////////////////////////////
//LoanInstallmentClass class declaration//
////////////////////////////////
class LoanInstallmentClass extends ObserverClass{
    loanAmount = 0;
    loanInterestRate = 0;
    loanDuration = 0;
    constructor(elemId) {        
        super(elemId);       
    }
    notify = (function (elemVal, elemId) {

        // notification / update logic
        if (String(elemId).includes("LoanAmount")) { this.loanAmount = elemVal; }
        else if (String(elemId).includes("LoanInterestRate")) { this.loanInterestRate = elemVal; }        
        else if (String(elemId).includes("LoanDuration")) { this.loanDuration = elemVal; }        

        if (this.loanAmount > 0 && this.loanInterestRate > 0 && this.loanDuration > 0) {

            var loanInstallment = CalculateLoanInstallment(this.loanAmount, this.loanInterestRate, this.loanDuration);
            $("#" + this.elementId).val(loanInstallment);

        }

        $("#" + this.elementId).trigger('change');

    }).bind(this)
}

class LoanInstallmentSumClass extends ObserverClass {
    loanInstallment = 0;
    loanDuration = 0;

    constructor(elemId) {
        super(elemId);
    }
    notify = (function (elemVal, elemId) {

        // notification / update logic
        if (String(elemId).includes("LoanInstallment")) { this.loanInstallment = elemVal; }
        else if (String(elemId).includes("LoanDuration")) { this.loanDuration = elemVal; }   

        if (this.loanInstallment > 0 && this.loanDuration > 0) {

            var loanInstallmentSum = this.loanInstallment * this.loanDuration;
            $("#" + this.elementId).val(loanInstallmentSum);

        }


    }).bind(this)
}
////////////////////////////////
//Observable class declaration//
////////////////////////////////
class ObservableClass{
    constructor(elemId) {
        this.elementId = elemId;
        this.observerList = new Array();
    }
    notifyObservers = (function() {
        for (var i = 0; i < this.observerList.length; i++) {
            this.observerList[i].notify($("#" + this.elementId).val(), this.elementId);
        }
        console.log("notify observers");
    }).bind(this)
    addObserver = (function (observerObj) {
        this.observerList.push(observerObj);
        console.log("observer added: " + observerObj.elementId);
    }).bind(this)
    AttatchFocusOut = (function () {
        $("#" + this.elementId).focusout(this.notifyObservers);
    }).bind(this)
    AttatchOnChange = (function () {
        $("#" + this.elementId).change(this.notifyObservers);
    }).bind(this)
}

function CalculateLoanInstallment(loanAmount = 1, loanInterestRate = 1, durationMonths = 1) {
    var loanInterestRateFloat = loanInterestRate / 100;
    var loanInstallment = (((loanInterestRateFloat / 12) * loanAmount) / (1 - (Math.pow(1 + (loanInterestRateFloat / 12), ((durationMonths / 12) * -12))))).toFixed(2);
    return loanInstallment;
}

$(document).ready(function () {           

    ////using prototype
    ////observer pattern setup
    ////add observables considering their id's
    //var ObservableUIElem = new ObservableObj("CustomerNameTextBox");
    //var ObservableUIElem2 = new ObservableObj("LoanDescriptionTextBox");

    ////add observers considering their id's
    //var observerElem = new ObserverObj("LoanDescriptionTextBox");
    //var observerElem2 = new ObserverObj("InstallmentValueTextBox");

    ////add observers to observables
    //ObservableUIElem.addObserver(observerElem);
    //ObservableUIElem2.addObserver(observerElem2);
    ////attatch focusout
    //ObservableUIElem.AttatchFocusOut();
    //ObservableUIElem2.AttatchFocusOut();

    //using classes
    //observer pattern setup
    //add observables considering their id's
    var ObservableUIloanAmount = new ObservableClass("LoanAmountTextBox");
    var ObservableUIinterestRate = new ObservableClass("LoanInterestRateTextBox");
    var ObservableUIloanDuration = new ObservableClass("LoanDurationTextBox");
    var ObservableUIloanInstallment = new ObservableClass("LoanInstallmentTextBox");
    //TODO remaining fields

    //add observers considering their id's
    var observerLoanInstallment = new LoanInstallmentClass("LoanInstallmentTextBox");
    var observerLoanInstallmentSum = new LoanInstallmentSumClass("LoanInstallmentSumTextBox");
    //TODO remaining fields

    //add observers to observables
    ObservableUIloanAmount.addObserver(observerLoanInstallment);
    ObservableUIinterestRate.addObserver(observerLoanInstallment);
    ObservableUIloanDuration.addObserver(observerLoanInstallment);

    ObservableUIloanDuration.addObserver(observerLoanInstallmentSum);
    ObservableUIloanInstallment.addObserver(observerLoanInstallmentSum);

    //attatch focusout
    ObservableUIloanAmount.AttatchFocusOut();
    ObservableUIinterestRate.AttatchFocusOut();
    ObservableUIloanDuration.AttatchFocusOut();
    ObservableUIloanInstallment.AttatchOnChange();


    //legacy attach
    //$("#CustomerNameTextBox").focusout(function (elm) {
    //    var textBoxText = $("#CustomerNameTextBox").val();
    //    $("#LoanDescriptionTextBox").val(textBoxText+"'s loan");
    //});
});
