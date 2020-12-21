import { Person } from "./person";
import { PhoneNumberType } from "./phone-number-type";

export interface PhoneNumberTypeResponse {
    phoneNumberTypeObjects:PhoneNumberType[],
    success:Boolean,
    errors:String[]
}
