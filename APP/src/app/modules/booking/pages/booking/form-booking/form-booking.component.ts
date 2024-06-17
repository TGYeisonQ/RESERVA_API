import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-form-booking',
  templateUrl: './form-booking.component.html',
  styleUrl: './form-booking.component.scss'
})
export class FormBookingComponent {
  @Input() display: boolean = false;
  @Input() data: any = {};
  @Output() displayChange = new EventEmitter<boolean>();
  @Output() saveData = new EventEmitter<any>();

  save() {
    this.saveData.emit(this.data);
    this.close();
  }

  close() {
    this.displayChange.emit(false);
  }
}
