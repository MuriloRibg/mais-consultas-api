using System;

public class Address{
    public int Id {get; protected set;}
    public string LineOne {get; protected set;}
    public string LineTwo {get; protected set;}
    public int ZipCode {get; protected set;}
    public string City {get; protected set;}
    public string State {get; protected set;}

    public Address(int id, string lineOne, string lineTwo, int zipCode, string city, string state){
        Id = id;
        SetLineOne(lineOne);
        SetLineTwo(lineTwo);
        SetZipCode(zipCode);
        SetCity(city);
        SetState(state);
    }

    public void SetLineOne(string lineOne){
        LineOne = lineOne;
    }

    public void SetLineTwo(string lineTwo){
        LineTwo = lineTwo;
    }

    public void SetZipCode(int zipCode){
        ZipCode = zipCode;
    }

    public void SetCity(string city){
        City = city;
    }

    public void SetState(string state){
        State = state;
    }
}