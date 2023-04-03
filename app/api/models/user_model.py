import datetime
from uuid import UUID


class User:
    def __init__(self, user_id: UUID, fullname: str, email: str, 
                 password: str, roles: list[str], createdOn: datetime, modifiedOn: datetime):
        self.id = user_id
        self.name = fullname
        self.email = email
        self.password = password
        self.roles = roles
        self.createdOn = createdOn
        self.modifiedOn = modifiedOn
        
    def __str__(self):
        return f"User(id={self.id}, name={self.name}, email={self.email}, roles={self.roles})"

    