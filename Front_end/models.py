from pydantic import BaseModel

class RegisterRequest(BaseModel):
    Username:str
    Password:str
    LicenseNumber:str
    Ssn:str
    
class LoginRequest(BaseModel):
    Username:str
    Password:str