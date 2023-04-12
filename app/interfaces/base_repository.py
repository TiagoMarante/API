from abc import ABC, abstractmethod

class IBaseRepository(ABC):
    @abstractmethod
    def read_by_options(self, schema, eager=False):
        pass

    @abstractmethod
    def read_by_id(self, id: int, eager=False):
        pass

    @abstractmethod
    def create(self, schema):
        pass

    @abstractmethod
    def update(self, id: int, schema):
        pass

    @abstractmethod
    def update_attr(self, id: int, column: str, value):
        pass

    @abstractmethod
    def whole_update(self, id: int, schema):
        pass

    @abstractmethod
    def delete_by_id(self, id: int):
        pass
