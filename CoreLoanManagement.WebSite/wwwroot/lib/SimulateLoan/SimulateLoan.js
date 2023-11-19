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
        this.loanDuration = 1;
    }
    notify = (function (elemVal, elemId) {

        if (String(elemId).includes("LoanAmount")) { this.loanAmount = elemVal; }
        else if (String(elemId).includes("LoanInterestRate")) { this.loanInterestRate = elemVal; }        
        $("#" + this.elementId).val(CalculateLoanInstallment(this.loanAmount, this.loanInterestRate, this.loanDuration));
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
}

function CalculateLoanInstallment(loanAmount=1, loanInterestRate=1, duration = 1) {
    return (Number(loanAmount) * (Number(duration) + (Number(loanInterestRate) / Number(100)))) / Number(12);
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
    var ObservableUIElem = new ObservableClass("LoanAmountTextBox");
    var ObservableUIElem2 = new ObservableClass("LoanInterestRateTextBox");
    //TODO remaining fields

    //add observers considering their id's
    var observerElem = new LoanInstallmentClass("LoanInstallmentTextBox");
    //TODO remaining fields

    //add observers to observables
    ObservableUIElem.addObserver(observerElem);
    ObservableUIElem2.addObserver(observerElem);
    //attatch focusout
    ObservableUIElem.AttatchFocusOut();
    ObservableUIElem2.AttatchFocusOut();

    //legacy attach
    //$("#CustomerNameTextBox").focusout(function (elm) {
    //    var textBoxText = $("#CustomerNameTextBox").val();
    //    $("#LoanDescriptionTextBox").val(textBoxText+"'s loan");
    //});
});
