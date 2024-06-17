import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IBookingResponse } from '../models/Interface/IBookingResponse.interface';
import { API_URL } from '../shared/constants/api';
import { IBookingRequest, IBookingRequestFilter } from '../models/Interface/IBookingRequest.interface';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  constructor(private http: HttpClient) { }

  getData(payload: IBookingRequestFilter): Observable<IBookingResponse[]> {
    let params = new HttpParams();

    if(payload.DateBooking)
      params = params.append('DateBooking', payload.DateBooking);

    if(payload.ServiceId)
      params = params.append('ServiceId', payload.ServiceId);

    if(payload.UserId)
      params = params.append('UserId', payload.UserId);

    return this.http.get<IBookingResponse[]>(`${API_URL}/Booking`, { params: params});
  }

  createData(payload: IBookingRequest): Observable<any> {
    return this.http.post<any>(`${API_URL}/Booking`, payload);
  }

  updateData(payload: IBookingRequest): Observable<any> {
    return this.http.put<any>(`${API_URL}/Booking`, payload);
  }

  deleteData(id: string): Observable<any> {
    return this.http.delete<any>(`${API_URL}/Booking/${id}`);
  }
}
