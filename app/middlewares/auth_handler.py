# This file is responsible for signing , encoding , decoding and returning JWTS
from datetime import datetime
import time
from typing import Dict
import uuid

import jwt
from decouple import config


JWT_SECRET = config("secret")
JWT_ALGORITHM = config("algorithm")


def token_response(token: str):
    return {
        "access_token": token
    }

# function used for signing the JWT string
def signJWT(user_id: uuid) -> Dict[str, str]:
    payload = {
        "user_id": str(user_id),
        "exp": time.time() + 600
    }
    token = jwt.encode(payload, JWT_SECRET, algorithm=JWT_ALGORITHM)
    return token_response(token)


def decode_jwt(token: str) -> dict:
    try:
        decoded_token = jwt.decode(token, JWT_SECRET, algorithms=JWT_ALGORITHM)
        return decoded_token if decoded_token["exp"] >= int(round(datetime.utcnow().timestamp())) else None
    except Exception as e:
        return {}
