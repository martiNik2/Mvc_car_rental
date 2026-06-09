from pyscript import when, web
from pyodide.http import pyfetch
import models

BACKEND_URL="http://127.0.0.1:placeholder" #FIX THIS SHIT

def show_register(event):
    web.page["login"].classes.remove("active")
    web.page["register"].classes.add("active")
    
    
async def send_reg(event):
    
    res=web.page.find("div.active div.input-group input")
    
    if res[1].value!=res[2].value:
        print("HUH?!?")
    
    register=models.RegisterRequest(
        Username=str(res[0].value),
        Password=str(res[1].value),
        LicenseNumber=str(res[3].value),
        Ssn=str(res[4].value)
    )
    
    
    try:
        response = await pyfetch(
            url=BACKEND_URL,
            method="POST",
            headers={"Content-type" : "application/json"},
            payload=register.json()
        )
        print(response)
    except:
        if response.ok:
            print("all good")
        else:
            print("WE GOT A PROBLEM")


    print(register)

async def send_log(event):
    res=web.page.find("div.active div.input-group input")

    Username=res[0].value
    Password=res[1].value
    

    login_request=models.LoginRequest(Username=Username,Password=Password)

    try:
        response = await pyfetch(
            url=BACKEND_URL,
            method="POST",
            headers={"Content-type":"application/json"},
            payload=login_request.json()
        )

        print(response)
    except:
        if response.ok:
            print("all good")
        else:
            print("problem?")

