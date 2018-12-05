import {Component, Input, OnInit} from '@angular/core';
import {EmployeeDetail} from '../employeedetail';
import {EmployeeService} from '../employee.service';

@Component({
  selector: 'app-get-single-employee',
  templateUrl: './get-single-employee.component.html',
  styleUrls: ['./get-single-employee.component.css']
})
export class GetSingleEmployeeComponent implements OnInit {
  @Input() employeedetail: EmployeeDetail[]

  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {
  }
  
  getSingleEmployee(employeeId): void {
  	document.getElementById("error").innerHTML = "";
        this.employeeService.getSingleEmployee(employeeId)
          .subscribe(employeedetail => this.employeedetail = employeedetail, error => document.getElementById("error").innerHTML = "Employee Not Found");
  }

}