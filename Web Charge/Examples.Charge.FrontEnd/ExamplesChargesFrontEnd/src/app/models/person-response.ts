import { Person } from "./person";

export interface PersonResponse {
    personObjects:Person[],
    success:Boolean,
    errors:String[]
}
