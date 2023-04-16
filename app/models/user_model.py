
from sqlmodel import Field
from app.models.base_model import BaseModel

class User(BaseModel, table=True):
    email: str = Field(unique=True)
    password: str = Field()
    name: str = Field(default=None, nullable=True)
