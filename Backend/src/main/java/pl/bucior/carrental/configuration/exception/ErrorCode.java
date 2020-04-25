package pl.bucior.carrental.configuration.exception;

public enum ErrorCode {

    UNAUTHORIZED,
    INTERNAL_ERROR,
    VALIDATION_ERROR,
    NOT_ALLOWED,
    USER_NOT_FOUND,
    EMAIL_ALREADY_EXISTS,
    CAR_NOT_FOUND,
    AGENCY_NOT_FOUND,
    INVAILD_ROLE,
    CONTRACT_EXPIRED,
    AGENCY_HAS_USER_NOT_FOUND,
    INVAILD_START_OR_END_CONTRACT_DATE,
    USER_IS_ALREADY_EMPLOYED,
    PRICE_LIST_NOT_FOUND,
    CAR_IS_ALREADY_RENTED,
    USER_HAS_OPENED_RENT,
    CANNOT_DELETE_CAR_WITH_OPEN_RENT,
    RENT_NOT_FOUND,
    CAR_HAS_OPENED_TECHNICAL_SUPPORT

}
