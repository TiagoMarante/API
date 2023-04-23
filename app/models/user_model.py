
from sqlmodel import Field
from app.models.base_model import BaseModel

class User(BaseModel, table=True):
    email: str = Field(unique=True)
    password: str = Field()
    name: str = Field(default=None, nullable=True)
    #roles: List[Roles] = Relationship(back_populates="users")

    #def add_role(self, role: Roles):
    #    if role not in self.roles:
    #        self.roles.append(role)

    #def remove_role(self, role: Roles):
    #    if role in self.roles:
    #        self.roles.remove(role)