from fastapi import APIRouter, Depends
from app.api.schemas.PostSchema import PostSchema
from app.middlewares.auth_bearer import JWTBearer

from app.repositories.post_repository import posts

post_router = APIRouter()


@post_router.get("/", tags=["test"])
async def greet():
    return {"Hello": "Bywe"}

@post_router.get("/posts", dependencies=[Depends(JWTBearer())], tags=["posts"])
async def get_posts():
    return {"data": posts}

@post_router.get("/posts/{id}", tags=["posts"])
async def get_single_post(id: int):
    if id > len(posts):
        return {"error": "No such post with the supplied ID."}

    for post in posts:
        if post["id"] == id:
            return {"data": post}

@post_router.post("/posts", dependencies=[Depends(JWTBearer())], tags=["posts"])
async def add_post(post: PostSchema):
    post.id = len(posts) + 1
    posts.append(post.dict())
    return {"data": "post added."}
