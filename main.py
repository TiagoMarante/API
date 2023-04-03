
from fastapi import FastAPI

from app.api.routes.post import post_router
from app.api.routes.users import users_router



posts = [
    {
        "id": 1,
        "title": "Penguins ",
        "text": "Penguins are a group of aquatic flightless birds."
    },
    {
        "id": 2,
        "title": "Tigers ",
        "text": "Tigers are the largest living cat species and a memeber of the genus panthera."
    },
    {
        "id": 3,
        "title": "Koalas ",
        "text": "Koala is arboreal herbivorous maruspial native to Australia."
    },
]



app = FastAPI()
app.include_router(post_router)
app.include_router(users_router)

