export interface IBookingRequestFilter {
    DateBooking?: string;
    UserId?: string;
    ServiceId?: string;
}

export interface IBookingRequest {
    id?: string;
    dateBooking : Date;
    serviceId: string;
    userId : string;
    title : string;
    observations : string;   
}