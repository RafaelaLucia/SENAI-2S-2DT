import {View, Text, Alert, Modal, Image, ImageBackground, TouchableOpacity, StyleSheet, AsyncStorage} from 'react-native'
import React, {useState} from 'react';
import {RNCamera} from 'react-native-camera';
import topo from '../../assets/img/profile2x.png';

const Camera = ({isVisible, onChangePhoto, onCloseCamera}) => {
    const [camera, setCamera] = useState();
    const onTakePicture = async () => {
        try {
            const {uri} = await camera.takePictureAsync({
                quality: 0.5,
                forceUpOrientation: true,
                fixOrientation: true,
                skipProcessing: true
            });
            onChangePhoto(uri);
        } catch (error) {
            Alert.alert('Erro ao tirar a foto.')
        }
    }

    return(
        <Modal
        //pop up
        animationType='slide' 
        transparent={false}
        visible={isVisible}
        >
         <RNCamera
         ref={ref => setCamera(ref)}
         style={{flex:1}}
         type={RNCamera.Constants.Type.back}
         autoFocus={RNCamera.Constants.AutoFocus.on}
         flashMode={RNCamera.Constants.FlashMode.off}
         androidCameraPermissionOptions={{
             title: 'Permissão para usar a câmera',
             message: 'Precisamos da sua permissão para acessar a Câmera',
             buttonPositive: 'OK',
             buttonNegative: 'Cancelar'
         }}
         captureAudio={false}
         >
        <View
         style={styles.snapWrapper}
        >
         <TouchableOpacity
         onPress={onTakePicture}
         style={style.capture}
         >
             <text style={style.snapText}>FOTO</text>
         </TouchableOpacity>
        </View>
         </RNCamera>
        </Modal>
    )





}

const CameraPerfil = () => {
    const[isCameraVisible, setIsCameraVisible] = useState(false);
    const[photo, setPhoto] = useState(null);
    const onChangePhoto = newPhoto => {
        //recuperar o caminho da img e converter para base64
        ImgToBase64.getBase64String(newPhoto).then(base64String => console.warn(base64String))
        setPhoto(newPhoto);
        setIsCameraVisible(false);
    }

    const Confirmar = async () => {
        const token = await AsyncStorage.getItem ('userToken')
        var foto_confirmada = {
            uri: photo,
            type: 'image/jpeg',
            name: 'photo.jpg'
        }
        const formData = new FormData()
        formData.append('arquivo',foto_confirmada)
    }

    const onCloseCamera = () => {
        setIsCameraVisible(false);
    };
    return(
        <View
        style={styles.container}>
          <Image source={topo} style={styles.topo}/>
          <View
          style={styles.photo}
          >
          <ImageBackground source={{uri: photo}} style={{height:'100%', width:'100%'}}/>
          </View>
        </View>
    )

}

export default CameraPerfil;