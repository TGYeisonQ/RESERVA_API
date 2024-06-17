import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { TableModule } from 'primeng/table';  
import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { DropdownModule } from 'primeng/dropdown';
import { TagModule } from 'primeng/tag';

import { BookingRoutingModule } from './booking-routing.module';
import { BookingComponent } from './pages/booking/booking.component';
import { FormBookingComponent } from './pages/booking/form-booking/form-booking.component';



@NgModule({
  declarations: [
    BookingComponent,
    FormBookingComponent
  ],
  imports: [
    TagModule,
    TableModule,
    DialogModule,
    FormsModule,  
    ButtonModule,
    InputTextModule,
    DropdownModule,
    ReactiveFormsModule,
    BookingRoutingModule,
  ],
  exports: [

  ]
})
export class BookingModule { }
