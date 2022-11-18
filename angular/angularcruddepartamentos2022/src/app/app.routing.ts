import { Routes, RouterModule } from "@angular/router";
import {ModuleWithProviders} from '@angular/core';
import { DepartamentosComponent } from "./components/departamentos/departamentos.component";
import { InsertardepartamentoComponent } from "./components/insertardepartamento/insertardepartamento.component";

const appRoutes: Routes=[
    {path: "", component: DepartamentosComponent},
    {path: "insertar", component: InsertardepartamentoComponent}
]

export const appRoutingProviders: any[] = []
export const routing: ModuleWithProviders<any> = 
RouterModule.forRoot(appRoutes);
