import { IServiceResponse } from "./IServiceResponse.interface";
import { IUserResponse } from "./IUserResponse.interface";

export interface IBookingResponse {
    id : string;
    title : string;
    observations : string;
    dateBooking : string;
    user : IUserResponse;
    service: IServiceResponse;
}