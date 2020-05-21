import { ReconciliationsComponent } from './../../pages/reconciliations/reconciliations.component';
import { CollectionsComponent } from './../../pages/collections/collections.component';
import { ExpensesComponent } from './../../pages/expenses/expenses.component';
import { RequisitionsComponent } from './../../pages/requisitions/requisitions.component';
import { Routes } from '@angular/router';

import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { IconsComponent } from '../../pages/icons/icons.component';
import { MapsComponent } from '../../pages/maps/maps.component';
import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
import { TablesComponent } from '../../pages/tables/tables.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'dashboard', component: DashboardComponent },
    { path: 'user-profile', component: UserProfileComponent },
    { path: 'collections', component: CollectionsComponent },
    { path: 'requisitions', component: RequisitionsComponent },
    { path: 'expenses', component: ExpensesComponent },
    { path: 'reconciliations', component: ReconciliationsComponent },
    // { path: 'tables',         component: TablesComponent },
    { path: 'icons',          component: IconsComponent },
    // { path: 'maps',           component: MapsComponent }
];
