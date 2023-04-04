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
    print("teste")
    try:
        payload = decodeJWT(token)
        print(payload)
        idx = str(payload["user_id"])
        print(idx)
        user_id = uuid.UUID(idx)
        return JWTUser(id=user_id)
    except (jwt.exceptions.DecodeError, jwt.exceptions.InvalidSignatureError):
        print("error")
        raise HTTPException(status_code=status.HTTP_401_UNAUTHORIZED, detail="Invalid token")