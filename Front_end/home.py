from pyscript import web, when


def load_home():
    element=web.page.find(".active")[0]
    element.classes.remove("active")
    
    parent_div=web.page.find("#home")[0]
    parent_div.classes.add("active")
    
    header=web.h1(
        "WElcome to CARS"
    )
    
    web.page.append(header)
    