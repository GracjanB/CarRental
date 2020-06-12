package pl.bucior.carrental.mapper;

public interface ToDtoMapper<T, TDTO> {
    TDTO toDto(T var1);
}