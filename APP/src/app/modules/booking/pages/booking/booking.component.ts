import { Component, OnInit } from '@angular/core';
import { Table } from 'primeng/table';

interface Data {
  name: string;
  email: string;
}

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrl: './booking.component.scss'
})
export class BookingComponent implements OnInit {
  data: Data[] = [
    { name: 'John Doe', email: 'john.doe@example.com' },
    { name: 'Jane Roe', email: 'jane.roe@example.com' }
    // Agrega más datos según sea necesario
  ];

  selectedData: Data = { name: '', email: '' };
  displayDialog: boolean = false;

  constructor() { }

  ngOnInit(): void { }

  openDialog(rowData: Data) {
    this.selectedData = { ...rowData };
    this.displayDialog = true;
  }

  handleSave(updatedData: any) {
    const index = this.data.findIndex(item => item.email === updatedData.email);
    if (index !== -1) {
      this.data[index] = updatedData;
    }
  }

  filterGlobal(event: Event, dt: any) {
    const input = event.target as HTMLInputElement;
    dt.filterGlobal(input.value, 'contains');
  }

  filterColumn(event: Event, field: string, dt: any) {
    const input = event.target as HTMLInputElement;
    dt.filter(input.value, field, 'contains');
  }
}
