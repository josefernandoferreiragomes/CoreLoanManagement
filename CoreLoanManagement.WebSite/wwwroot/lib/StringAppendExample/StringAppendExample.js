﻿////////////////////////////////
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
        console.log("class observer notify")
        $("#" + this.elementId).val("1 " + elemVal);
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
            this.observerList[i].notify($("#" + this.elementId).val());
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

$(document).ready(function () {           

    ////using prototype
    ////observer pattern setup
    ////add observables considering their id's
    //var ObservableUIElem = new ObservableObj("FirstStringTextBox");
    //var ObservableUIElem2 = new ObservableObj("SecondStringTextBox");

    ////add observers considering their id's
    //var observerElem = new ObserverObj("SecondStringTextBox");
    //var observerElem2 = new ObserverObj("ThirdStringTextBox");

    ////add observers to observables
    //ObservableUIElem.addObserver(observerElem);
    //ObservableUIElem2.addObserver(observerElem2);
    ////attatch focusout
    //ObservableUIElem.AttatchFocusOut();
    //ObservableUIElem2.AttatchFocusOut();

    //using classes
    //observer pattern setup
    //add observables considering their id's
    var ObservableUIElem = new ObservableClass("FirstStringTextBox");
    var ObservableUIElem2 = new ObservableClass("SecondStringTextBox");

    //add observers considering their id's
    var observerElem = new ObserverClass("SecondStringTextBox");
    var observerElem2 = new ObserverClass("ThirdStringTextBox");

    //add observers to observables
    ObservableUIElem.addObserver(observerElem);
    ObservableUIElem2.addObserver(observerElem2);
    //attatch focusout
    ObservableUIElem.AttatchFocusOut();
    ObservableUIElem2.AttatchFocusOut();

    //legacy attach
    //$("#FirstStringTextBox").focusout(function (elm) {
    //    var textBoxText = $("#FirstStringTextBox").val();
    //    $("#SecondStringTextBox").val(textBoxText+"'s loan");
    //});
});
