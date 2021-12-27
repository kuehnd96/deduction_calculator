import { Component, OnInit } from '@angular/core';
import { Dependent} from '../models/dependent';
import { Employee} from '../models/employee';
import { webClient } from '../backend/webClient';

@Component({
  selector: 'app-employee-deduction',
  templateUrl: './employee-deduction.component.html',
  styleUrls: ['./employee-deduction.component.css']
})
export class EmployeeDeductionComponent implements OnInit {
  firstName?: string;
  lastName?: string;
  dependents?: Dependent[];


  constructor() { }

  ngOnInit(): void {
  }

}
