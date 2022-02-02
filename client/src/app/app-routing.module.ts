import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { HomeComponent } from './home/home.component';
import { ListsComponent } from './lists/lists.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MessagesComponent } from './messages/messages.component';
import { AuthGuard } from './_guards/auth.guard';
import { PreventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';
import { MemberDetailedResolver } from './_resolvers/member-detailed.resolver';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { AdminGuard } from './_guards/admin.guard';
import { LandingComponent } from './landing/landing.component';
import { TxqohComponent } from './inventory/txqoh/txqoh.component';
import { TxqohCreateComponent } from './inventory/txqoh-create/txqoh-create.component';
import { TxqohModalComponent } from './inventory/txqoh-modal/txqoh-modal.component';
import { PurchaseordersComponent } from './supplychain/purchaseorders/purchaseorders.component';
import { PoplanCreateComponent } from './supplychain/poplan-create/poplan-create.component';
import { PoplanModalComponent } from './supplychain/poplan-modal/poplan-modal.component';
import { SalesComponent } from './sales/sales.component';
import { SalesCreateComponent } from './sales/sales-create/sales-create.component';
import { SoplanModalComponent } from './sales/soplan-modal/soplan-modal.component';
import { ShipoutsComponent } from './sales/shipouts/shipouts.component';
import { SertanComponent } from './sales/sertan/sertan.component';
import { TxqohactualsComponent } from './inventory/txqohactuals/txqohactuals.component';
import { InventoryComponent } from './inventory/inventory.component';
import { ReceivedComponent } from './supplychain/received/received.component';
import { TransitComponent } from './supplychain/transit/transit.component';
import { SupplychainComponent } from './supplychain/supplychain.component';
import { SlottedComponent } from './sales/slotted/slotted.component';
import { SalesListComponent } from './sales/sales-list/sales-list.component';
import { PoplanDetailComponent } from './supplychain/poplan-detail/poplan-detail.component';
import { PoPlanDetailedResolver } from './_resolvers/poplan-detailed.resolver';
import { QuoteComponent } from './supplychain/quote/quote.component';
import { QuoteCreateComponent} from './supplychain/quote/quote-create/quote-create.component';
import { QuoteDetailComponent } from './supplychain/quote/quote-detail/quote-detail.component';
import { QuoteListComponent } from './supplychain/quote/quote-list/quote-list.component';
import { FinanceComponent } from './finance/finance.component';
import { ExpensesComponent } from './finance/expenses/expenses.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {path: 'members', component: MemberListComponent},
      {path: 'landing', component: LandingComponent},
      {path: 'inventory', component: InventoryComponent},
      {path: 'txqoh', component: TxqohComponent},
      {path: 'txqohactuals', component: TxqohactualsComponent},
      {path: 'txqoh-modal', component: TxqohModalComponent},      
      {path: 'txqoh-create', component: TxqohCreateComponent},
      {path: 'members/:username', component: MemberDetailComponent, resolve: {member: MemberDetailedResolver}},
      {path: 'member/edit', component: MemberEditComponent, canDeactivate: [PreventUnsavedChangesGuard]},
      {path: 'lists', component: ListsComponent},
      {path: 'messages', component: MessagesComponent},
      {path: 'purchaseorders', component: PurchaseordersComponent},
      {path: 'supplychain', component: SupplychainComponent},
      {path: 'poplan-create', component: PoplanCreateComponent},
      {path: 'poplan-detail/:id', component: PoplanDetailComponent, resolve: {poplan: PoPlanDetailedResolver}},
      {path: 'received', component: ReceivedComponent},
      {path: 'transit', component: TransitComponent},
      {path: 'poplan-modal', component: PoplanModalComponent},
      {path: 'sales', component: SalesComponent},
      {path: 'slotted', component: SlottedComponent},
      {path: 'sales-create', component: SalesCreateComponent},
      {path: 'sales-list', component: SalesListComponent},
      {path: 'soplan-modal', component: SoplanModalComponent},
      {path: 'shipouts', component: ShipoutsComponent},
      {path: 'sertan', component: SertanComponent},
      {path: 'quote', component: QuoteComponent},
      {path: 'quote-create', component: QuoteCreateComponent},
      {path: 'quote-list', component: QuoteListComponent},
      {path: 'quote-detail', component: QuoteDetailComponent},
      {path: 'finance', component: FinanceComponent},
      {path: 'expenses', component: ExpensesComponent},
      {path: 'admin', component: AdminPanelComponent, canActivate: [AdminGuard]},

    ]
  },
  {path: 'errors', component: TestErrorsComponent },
  {path: 'not-found', component: NotFoundComponent },
  {path: 'server-error', component: ServerErrorComponent },
  {path: '**', component: NotFoundComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
