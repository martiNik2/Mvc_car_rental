﻿using System.ComponentModel.DataAnnotations;

namespace Core;

public abstract class BaseEntity
{
    public Guid Id {get;set;}=Guid.NewGuid();
    public DateTime CreatedAt{get;set;}=DateTime.UtcNow;
}

public class User:BaseEntity
{
    public string UserName{get;set;}=string.Empty;
    public string PasswordHash{get;set;}=string.Empty;
    public string LicenceNumber{get;set;}=string.Empty;
    public required string SSN{get;set;}
}

public class Vehicle : BaseEntity
{
    public string Model{get;set;}=string.Empty;
    public string NumberPlate{get;set;}=string.Empty;
    public Guid? UserId{get;set;}
}

public class LoginRequest
{
    public required string Username{get;set;}
    public required string Password{get;set;}
}

