from datetime import datetime
from uuid import UUID

from pydantic import BaseModel

from app.models.user_model import User


class SignIn(BaseModel):
    email__eq: str
    password: str


class SignUp(BaseModel):
    email: str
    password: str
    name: str


class Payload(BaseModel):
    id: UUID
    email: str
    name: str
    is_superuser: bool


class SignInResponse(BaseModel):
    access_token: str
    expiration: datetime
    user_info: User
