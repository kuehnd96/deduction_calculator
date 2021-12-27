import { Component, OnInit } from '@angular/core';
import { Dependent} from '../models/dependent';
import { Employee} from '../models/employee';
import { webClient } from '../backend/webClient';
import { FormGroup, FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'app-employee-deduction',
  templateUrl: './employee-deduction.component.html',
  styleUrls: ['./employee-deduction.component.css']
})
export class EmployeeDeductionComponent implements OnInit {
  firstName?: string;
  lastName?: string;
  dependents: Dependent[] = new Array(4);

  employeeForm = new FormGroup({
    firstName: new FormControl(null, [Validators.required]),
    lastName: new FormControl(null, [Validators.required]),
  })

  dependentForm = new FormGroup({
    firstName: new FormControl(null, [Validators.required]),
    lastName: new FormControl(null, [Validators.required]),
  })

  constructor() { }

  ngOnInit(): void {
  }

  addDependent() : void {
    if (this.dependentForm.status == "VALID") {
      let newDependent = new Dependent();
      newDependent.firstName = this.dependentForm.controls['firstName'].value,
      newDependent.lastName = this.dependentForm.controls['lastName'].value
      
      this.dependents.push(newDependent);
    }
  }

  calculateDeduction() : void {

  }
}
