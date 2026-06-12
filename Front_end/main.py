from pyscript import when, web, fetch, window
import models,home

BACKEND_URL="http://127.0.0.1:5088/api/auth" 



def show_register(event):
    web.page["login"].classes.remove("active")
    web.page["register"].classes.add("active")
    
def show_login(event):
    web.page["register"].classes.remove("active")
    web.page["login"].classes.add("active")
    
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
    
    if not register.Username or not register.Password or not register.Ssn:
        print("error")
        return
    
    response=None
    try:
        response = await fetch(
            url=f"{BACKEND_URL}/register",
            method="POST",
            headers={"Content-type" : "application/json"},
            body=register.model_dump_json()
        )
        if response.ok:
            print("OK!!")
            
            
    except:
        print("WE GOT A FUCKING PROBLEM")



async def send_log(event):
    res=web.page.find("div.active div.input-group input")

    Username=str(res[0].value)
    Password=str(res[1].value)
    
    if not Username or not Password:
        print("error")
        return

    login_request=models.LoginRequest(Username=Username,Password=Password)

    response=None
    try:
        response = await fetch(
            url=f"{BACKEND_URL}/login",
            method="POST",
            headers={"Content-type":"application/json"},
            body=login_request.model_dump_json()
        )
        response=await response.json()
        token=response['token']
        window.localStorage.setItem("user_token",token)
        home.load_home()
    except Exception as e:
        print(f"exception:{e}")
        
        



