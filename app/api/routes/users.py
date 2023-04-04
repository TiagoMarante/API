from fastapi import APIRouter
from fastapi import Body
from app.api.schemas.LoginSchema import LoginSchema
from app.api.schemas.UserSchema import UserSchema
from app.middlewares.auth_bearer import JWTBearer
from app.middlewares.auth_handler import signJWT
from app.middlewares.current_user import JWTUser, get_current_user
from app.services.user_service import UserService
from fastapi import APIRouter, Depends



users_router = APIRouter()

##########Inject Service classes needs rework######
user_service = UserService()
###################################################

users = []

def check_user(data: LoginSchema):
    for user in users:
        if user.email == data.email and user.password == data.password:
            return True
    return False


@users_router.post("/user/signup", tags=["user"])
def create_user(user: UserSchema = Body(...)):
    try:
        service_response = user_service.create_user(user)
        return signJWT(service_response.id)
    except:
        return {"error": "Email exist"}
    
    
@users_router.put("/user/update", dependencies=[Depends(JWTBearer())], tags=["user"])
def create_user(user: LoginSchema = Body(...), current_user: JWTUser = Depends(get_current_user)):
    try:
        current_user_id = current_user.id
        print(current_user_id)
        service_response = user_service.update_user(user)
        return signJWT(service_response.id)
    except:
        return {"error": "Email exist"}
    


@users_router.post("/user/login", tags=["user"])
def user_login(user: LoginSchema = Body(...)):
    if check_user(user):
        return signJWT(user.id)
    return {
        "error": "Wrong login details!"
    }