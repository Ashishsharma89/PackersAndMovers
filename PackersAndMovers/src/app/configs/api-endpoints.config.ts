export const ApiEndpoints = {
    auth: {
        LOGIN: 'auth/login',
        REGISTER: 'auth/register',
    },
    user: {
        GET_USER: 'user',
        UPDATE_PROFILE: 'user/update',
    },
    customers: {
        GET_CUSTOMERS: 'Customer',
        ADD_CUSTOMER: 'Customer',
    },
    drivers: {
        GET_DRIVERS: 'Driver',
        ADD_DRIVER: 'Driver',
        UPDATE_DRIVER_LOCATION: 'Driver/update-location',
        GET_DRIVER_BY_ID: (id: number) => `Driver/${id}`,
    },
    dashboard: {
        GET_DASHBOARD_STATS: 'Dashboard/stats',
        GET_DASHBOARD_TOP_CUSTOMERS: 'Dashboard/top-customers',
        GET_DASHBOARD_MONTHLY_TRENDS: 'Dashboard/monthly-trends',
    }
};