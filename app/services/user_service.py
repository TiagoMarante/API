from datetime import datetime
from typing import List
from app.api.models.user_model import User

from app.api.schemas.UserSchema import UserSchema

users = []

class UserService:

    def create_user(self, user: UserSchema):
        new_user = User(user.id, user.fullname, user.email, user.password, user.roles, datetime.utcnow(), datetime.utcnow())
        users.append(new_user)
        return new_user

    def update_user(self, user_id: int, name: str, email: str) -> User:
        for user in self.users:
            if user.id == user_id:
                user.name = name
                user.email = email
                return user
        return None

    def delete_user(self, user_id: int):
        for i, user in enumerate(self.users):
            if user.id == user_id:
                del self.users[i]
                return True
        return False

    def get_user_by_id(self, user_id: int) -> User:
        for user in self.users:
            if user.id == user_id:
                return user
        return None

    def get_users(self, limit: int = 100) -> List[User]:
        return self.users[:limit]
