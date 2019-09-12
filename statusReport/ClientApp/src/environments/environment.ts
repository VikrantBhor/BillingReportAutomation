// This file can be replaced during build by using the `fileReplacements` array.
// `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  //For Dev
  config: {
   // tenant: 'careportfol.io',
    tenant: 'ATIDAN2.onmicrosoft.com',
    clientId: '95becc1f-0f6d-4da6-aa19-c2057867e3bd',
    postLogoutRedirectUri: 'http://localhost:49203/',
    cacheLocation: 'localStorage',
    endpoints: {
      'https://graph.microsoft.com': '74c3a4b1-a2a5-4e48-9d7b-434f36d335ed'
    },
    //production: true,
  }

  //For Test
  //config: {
  //  // tenant: 'careportfol.io',
  //  tenant: 'ATIDAN2.onmicrosoft.com',
  //  clientId: 'ceb11536-21be-4b02-812a-e2e13435e54b',
  //  postLogoutRedirectUri: 'http://testbillingreport:49205/',
  //  cacheLocation: 'localStorage',
  //  endpoints: {
  //    'https://graph.microsoft.com': '74c3a4b1-a2a5-4e48-9d7b-434f36d335ed'
  //  },
  //  //production: true,
  //}

};

/*
 * In development mode, to ignore zone related error stack frames such as
 * `zone.run`, `zoneDelegate.invokeTask` for easier debugging, you can
 * import the following file, but please comment it out in production mode
 * because it will have performance impact when throw error
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
