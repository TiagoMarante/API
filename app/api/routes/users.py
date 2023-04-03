from fastapi import APIRouter
from fastapi import Body
from app.api.schemas.LoginSchema import LoginSchema
from app.api.schemas.UserSchema import UserSchema
from app.middlewares.auth_handler import signJWT
from app.services.user_service import UserService


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
    result = user_service.create_user(user)
    print(result)
    users.append(user) # replace with db call, making sure to hash the password first
    return signJWT(user.email)


@users_router.post("/user/login", tags=["user"])
def user_login(user: LoginSchema = Body(...)):
    if check_user(user):
        return signJWT(user.email)
    return {
        "error": "Wrong login details!"
    }