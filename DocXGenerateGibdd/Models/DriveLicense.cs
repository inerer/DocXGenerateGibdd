using System;
using System.Collections.Generic;

namespace DocXGenerateGibdd.Models;

public class DriveLicense
{
    public List<string> CategoryTypes { get; set; } = new List<string>();
    
    public string? SecondName { get; set; }
    
    public string? FirstName { get; set; }
    
    public string? MiddleName { get; set; }
    
    public DateTime DateOfBirth { get; set; }
    
    public string? PlaceOfBirth { get; set; }
    
    public DateTime DateOfIssue { get; set; }
    
    public DateTime ExpirationDate { get; set; }
    
    public string? GIBDD { get; set; }
    
    public string? CertificateNumber { get; set; }
    
    public string? Photo { get; set; }
    
    public string? PlaceOfLiving { get; set; }
}