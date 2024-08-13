import PropTypes from 'prop-types';
// mui imports
import { ListSubheader, styled } from '@mui/material';

const NavGroupForMobile = ({ item }) => {
  const ListSubheaderStyle = styled((props) => <ListSubheader disableSticky {...props} />)(
    ({ theme }) => ({
      ...theme.typography.overline,
      fontWeight: '700',
      marginTop: theme.spacing(3),
      marginBottom: theme.spacing(0),
      color: theme.palette.text.primary,
      lineHeight: '26px',
      padding: '3px 12px',
    }),
  );
  return (
    <ListSubheaderStyle>{item.subheader}</ListSubheaderStyle>    
  );
};

NavGroupForMobile.propTypes = {
  item: PropTypes.object,
};

export default NavGroupForMobile;
