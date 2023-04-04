from fastapi import Depends, FastAPI, HTTPException, status
from fastapi.security import HTTPBearer, HTTPAuthorizationCredentials
from pydantic import UUID4
import jwt
import uuid
from decouple import config

from app.middlewares.auth_bearer import JWTBearer
from app.middlewares.auth_handler import decodeJWT


JWT_SECRET = config("secret")

class JWTUser:
    def __init__(self, id: UUID4):
        self.id = id

async def get_current_user(token: HTTPAuthorizationCredentials = Depends(JWTBearer())) -> JWTUser:
    try:
        payload = decodeJWT(token)
        id = str(payload["user_id"])
        user_id = uuid.UUID(id)
        return JWTUser(user_id)
    except (jwt.exceptions.DecodeError, jwt.exceptions.InvalidSignatureError):
        raise HTTPException(status_code=status.HTTP_401_UNAUTHORIZED, detail="Invalid token")