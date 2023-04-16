from uuid import UUID
from dependency_injector.wiring import Provide, inject
from fastapi import APIRouter, Depends

from app.core.container import Container
from app.core.security import JWTBearer
from app.schemas.base_schema import Blank
from app.schemas.user_schema import CreateUser, FindUser, FindUserResult, UpsertUser, User
from app.services.user_service import UserService

router = APIRouter(prefix="/user", tags=["user"], dependencies=[Depends(JWTBearer())])


@router.get("", response_model=FindUserResult)
@inject
async def get_user_list(
    find_query: FindUser = Depends(),
    service: UserService = Depends(Provide[Container.user_service])
):
    return service.get_list(find_query)


@router.get("/{user_id}", response_model=User)
@inject
async def get_user(
    user_id: UUID,
    service: UserService = Depends(Provide[Container.user_service])
):
    return service.get_by_id(user_id)


@router.post("", response_model=User)
@inject
async def create_user(
    user: CreateUser,
    service: UserService = Depends(Provide[Container.user_service])
):
    return service.add(user)


@router.patch("/{user_id}", response_model=User)
@inject
async def update_user(
    user_id: UUID,
    user: UpsertUser,
    service: UserService = Depends(Provide[Container.user_service])
):
    return service.patch(user_id, user)


@router.delete("/{user_id}", response_model=Blank)
@inject
async def delete_user(
    user_id: UUID,
    service: UserService = Depends(Provide[Container.user_service])
):
    return service.remove_by_id(user_id)
