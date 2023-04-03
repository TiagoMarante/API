from pydantic import BaseModel, Field, EmailStr
from typing import List
from datetime import datetime
from uuid import UUID, uuid4



class UserSchema(BaseModel):
    id: UUID = Field(default_factory=uuid4)
    fullname: str = Field(...)
    email: EmailStr = Field(...)
    password: str = Field(...)
    roles: List[str] = Field(...)
    createdOn: datetime = Field(default_factory=datetime.utcnow)
    modifiedOn: datetime = Field(default_factory=datetime.utcnow)

    class Config:
        schema_extra = {
            "example": {
                "fullname": "Joe Doe",
                "email": "joe@xyz.com",
                "password": "any",
                "roles": ["admin"]
            }
        }

    def modifed(self):
        if self.createdOn != None and self.modifiedOn != None:
            self.modifiedOn = datetime.utcnow()

