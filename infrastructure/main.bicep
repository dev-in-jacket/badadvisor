param environment string 
param resourcePostfix string
param location string = resourceGroup().location

module storageAccount 'resources/storageAccount.bicep' = {
  name: 'storageAccount-deployment'
  params: {
    environment: environment
    resourcePostfix: resourcePostfix
    location: location
  }
}
