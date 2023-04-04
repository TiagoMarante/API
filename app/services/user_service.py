from datetime import datetime
from typing import List, Optional, Type
from uuid import UUID
from app.api.models.user_model import User

from app.api.schemas.UserSchema import UserSchema

users = []

class UserService:

    def create_user(self, user: UserSchema) -> User:
        new_user = User(user.id, user.fullname, user.email, user.password, user.roles, datetime.utcnow(), datetime.utcnow())
        #check if user with same email exist
        user = self.get_user_by_attribute("email", user.email, new_user)
        if user:
            raise
        users.append(new_user)
        return new_user
        

    def update_user(self, user_update: UserSchema) -> User:
        user: UserSchema = self.get_user_by_attribute("id", user.id, user_update)
        if not user:
            raise UserNotFoundException("User not found") 
        
        email = self.get_user_by_attribute("email", user.email, user_update)
        if email:
            raise EmailAlreadyInUseException("Email already in use")
        
        user.email = user_update.email
        user.fullname = user_update.fullname
        
        users[users.index(user)] = user
        return user

    def delete_user(self, user_id: int):
        for i, user in enumerate(self.users):
            if user.id == user_id:
                del self.users[i]
                return True
        return False

    def get_user_by_attribute(self, attribute: str, value: str, user_type: Type[User]) -> Optional[User]:
        for user in users:
            print(hasattr(user, attribute))
            if hasattr(user, attribute) and getattr(user, attribute) == value and isinstance(user, user_type):
                return user
        return None

    def get_users(self, limit: int = 100) -> List[User]:
        return self.users[:limit]



# should be implementad separated
class UserNotFoundException(Exception):
    pass

class EmailAlreadyInUseException(Exception):
    pass