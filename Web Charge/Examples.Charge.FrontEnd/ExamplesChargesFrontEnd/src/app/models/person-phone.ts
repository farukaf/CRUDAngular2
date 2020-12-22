import { PhoneNumberType } from "./phone-number-type";

export interface PersonPhone {
    personID: Number,
    phoneNumber: String,
    phoneNumberTypeID: Number,
    phoneNumberType: PhoneNumberType | null
}
