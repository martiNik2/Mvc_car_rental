from pyscript import when, web
from pyodide.http import pyfetch
import models

def show_register(event):
    web.page["login"].classes.remove("active")
    web.page["register"].classes.add("active")
    
    
def send_reg(event):
    
    res=web.page.find("div.active div.input-group input")
    
    if res[1].value!=res[2].value:
        print("HUH?!?")
    
    register=models.RegisterRequest(
        Username=str(res[0].value),
        Password=str(res[1].value),
        LicenseNumber=str(res[3].value),
        Ssn=str(res[4].value)
    )
    
    
    
    print(register)