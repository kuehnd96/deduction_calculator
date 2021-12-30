import { Component, OnInit } from '@angular/core';
import { Dependent} from '../models/dependent';
import { Employee} from '../models/employee';
import { WebClient } from '../backend/webClient';
import { FormGroup, FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'app-employee-deduction',
  templateUrl: './employee-deduction.component.html',
  styleUrls: ['./employee-deduction.component.css']
})
export class EmployeeDeductionComponent implements OnInit {
  firstName?: string;
  lastName?: string;
  dependents: Dependent[] = new Array();
  deductionAmount: number = 0;
  grossPay: number = 52000; // 2000 per paycheck * 26 weeks
  takeHomePay: number = 0;

  employeeForm = new FormGroup({
    firstName: new FormControl(null, [Validators.required]),
    lastName: new FormControl(null, [Validators.required]),
  })

  dependentForm = new FormGroup({
    firstName: new FormControl(null, [Validators.required]),
    lastName: new FormControl(null, [Validators.required]),
  })

  constructor(private apiClient: WebClient) {

  }

  ngOnInit(): void {
  }

  addDependent() : void {
    if (this.dependentForm.status == "VALID") {
      let newDependent = new Dependent();
      newDependent.firstName = this.dependentForm.controls['firstName'].value,
      newDependent.lastName = this.dependentForm.controls['lastName'].value
      
      this.dependents.push(newDependent);

      this.dependentForm.controls['firstName'].setValue('');
      this.dependentForm.controls['lastName'].setValue('');
    }
  }

  calculateDeduction() : void {
    if (this.employeeForm.status == "VALID") {
      let employee = new Employee();
      employee.firstName = this.employeeForm.controls['firstName'].value;
      employee.lastName = this.employeeForm.controls['lastName'].value;

      employee.dependents = this.dependents;

      this.apiClient.calculateDeduction(employee).subscribe(deductionAmount => {
        this.deductionAmount = deductionAmount;
        this.takeHomePay = this.grossPay - this.deductionAmount;
      });
    }
  }
}
