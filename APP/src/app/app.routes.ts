import { Component } from '@angular/core';
import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: '',
        loadChildren: () => import('./modules/booking/booking.module').then(m => m.BookingModule)
    }
];
